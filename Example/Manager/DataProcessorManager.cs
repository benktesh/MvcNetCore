using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Example.Data;
using Example.Models;

namespace Example.Manager
{
    public interface IDataProcessorManager
    {
        Task<IList<DataProcessor>> GetDataProcessors();
        Task<DataProcessor> GetDataProcessor(Guid id);
        Task<Boolean> RemoveDataProcessor(Guid id);
        Task<Boolean> UpdateDataProcessor(DataProcessor model);
        Task<Boolean> CreateDataProcessor(DataProcessor model);
    }
    public class DataProcessorManager: IDataProcessorManager
    {
        private readonly AppDbContext _context;

        public DataProcessorManager(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<DataProcessor>> GetDataProcessors()
        {
            var dpEntities = await _context.DataProcessors.ToListAsync();
            return dpEntities;

        }

        public async Task<DataProcessor> GetDataProcessor(Guid id)
        {
            return await _context.DataProcessors.Include(p => p.Contacts)
                .SingleOrDefaultAsync(m => m.ID == id);
        }

        public async Task<bool> RemoveDataProcessor(Guid id)
        {
            var dataProcessor = await _context.DataProcessors.SingleOrDefaultAsync(m => m.ID == id);
            if (dataProcessor == null)
            {
                return false;
            }
            _context.DataProcessors.Remove(dataProcessor);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDataProcessor(DataProcessor model)
        {
            var existing = await _context.DataProcessors.Include(p => p.Contacts)
                .SingleOrDefaultAsync(m => m.ID == model.ID);
            if (existing == null)
            {
                return false;
            }
            _context.Entry(existing).CurrentValues.SetValues(model);

            //remove contacts that have been deleted
            foreach (var existingContact in existing.Contacts)
            {
                if (model.Contacts.All(c => c.Id != existingContact.Id))
                {
                    _context.Contacts.Remove(existingContact);
                }
            }
            //add or update new contacts
            foreach (var newContact in model.Contacts)
            {
                var current = existing.Contacts.SingleOrDefault(c => c.Id == newContact.Id);
                if (current != null)
                {
                    _context.Entry(current).CurrentValues.SetValues(newContact);
                }
                else
                {
                    existing.Contacts.Add(newContact);
                }
            }
            //TODO check if try catch (here or later)
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<Boolean> CreateDataProcessor(DataProcessor model)
        {
            try
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                //TODO log something
            }
            

        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Example.Manager;
using Microsoft.AspNetCore.Mvc;
using Example.Models;
using Example.ViewModel;

namespace Example.Controllers
{
    public class DataProcessorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDataProcessorManager _manager;
        

        public DataProcessorsController(IMapper mapper, IDataProcessorManager manager)
        { 
            _mapper = mapper;
            _manager = manager;
        }

        // GET: DataProcessors
        public async Task<IActionResult> Index()
        {
            //TODO pagination
            var dpEntities = await _manager.GetDataProcessors();
            var dpViewModels = _mapper.Map<IList<DataProcessor>, IList<DataProcessorEditViewModel>>(dpEntities);
            return View(dpViewModels);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var dp = new DataProcessorEditViewModel();

            return View(dp);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataProcessor = await _manager.GetDataProcessor((Guid) id);
            if (dataProcessor == null)
            {
                return NotFound();
            }

            var vm = _mapper.Map<DataProcessorEditViewModel>(dataProcessor);
            return View(vm);
        }

        // POST: DataProcessors1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var result = await _manager.RemoveDataProcessor(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        [ResponseCache(NoStore = true, Duration = 0)]
        // GET: DataProcessors/Create
        public IActionResult AddContact()
        {
            var contact = new ContactEditViewModel();
            return View(contact);
        }

        // POST: DataProcessors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] DataProcessorEditViewModel dpViewModel)
        {
            if (ModelState.IsValid)
            {
                dpViewModel.ID = Guid.NewGuid();
                dpViewModel.Contacts.ForEach(p => p.Id = Guid.NewGuid());
                
                var dataProcessor = _mapper.Map<DataProcessorEditViewModel, DataProcessor>(dpViewModel);

                var result = await _manager.CreateDataProcessor(dataProcessor);
                if (!result)
                {
                    //something meaning ful error message
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dpViewModel);
        }

        // GET: DataProcessors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataProcessor = await _manager.GetDataProcessor(id.GetValueOrDefault());
            if (dataProcessor == null)
            {
                return NotFound();
            }

            var vm = _mapper.Map<DataProcessorEditViewModel>(dataProcessor);
            return View(vm);

        }


        // POST: DataProcessors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind] DataProcessorEditViewModel dpViewModel)
        {
            if (ModelState.IsValid)
            {

                dpViewModel.Contacts.ForEach(p =>
                {
                    // ReSharper disable once RedundantAssignment
                    // ReSharper disable once UnusedVariable
                    var guid = p.Id ?? Guid.NewGuid();
                });

                var model = _mapper.Map<DataProcessorEditViewModel, DataProcessor>(dpViewModel);

                var result = await _manager.UpdateDataProcessor(model);
                if(!result)
                {
                    return NotFound("Record may have been deleted");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dpViewModel);
        }
        
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataProcessor = await _manager.GetDataProcessor(id.GetValueOrDefault());
            if (dataProcessor == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<DataProcessorEditViewModel>(dataProcessor);
            return View(vm);
        }
    }
}

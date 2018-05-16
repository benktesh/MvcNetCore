using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Data;

namespace Example.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if(!context.DataProcessors.Any())
            {
                //seed any data for this table

            }
            if (!context.DPSystems.Any())
            {
                //seed any data for this table

            }

            if (!context.SystemCapablities.Any())
            {
                //seed any data for this table

            }
            if (!context.SystemCodes.Any())
            {
                //seed any data for this table

            }
            context.SaveChanges();
        }
    }
}

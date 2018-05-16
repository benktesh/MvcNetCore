This is an example project for creating an app using MVC in .NetCore with EF, bootstrap, jQuery/Javascript



1. Create MVC Project
2. Add classes
3. Update package for EF for SQL Server:  Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 2.0.3
4. Add a folder for Data
5. Add a class ToyContext and create DBSEt.
	using Microsoft.EntityFrameworkCore;
	using Toy.Models;

	namespace Toy.Data
	{
		public class ToyContext: DbContext
		{
			public ToyContext(DbContextOptions<ToyContext> options) : base(options){}

			public DbSet<DataProcessor> DataProcessors { get; set; }
			public DbSet<DPSystem> DPSystems { get; set; }
			public DbSet<SystemCapablity> SystemCapablities { get; set; }
					public DbSet<SystemCode> SystemCodes { get; set; }
		}

	}
6. Add connectionn string to appsettings.json
7. Add code to initialize the database
8. Update main method to make db run as below:
	 var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ToyContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
9. Add controller (select model from context) and scafold view. (right click on controller and add and then follow the steps)
10. Change _Layout file to make it more like CMFG
11. Make views

12. Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
13. Wireup automapper in Startup file by adding services.AddAutoMapper();

TODO Items:
Add view model and Model layer to separate the model from DB models
Add automapper
Add StructureMap
Verify SSO currently it is using Windows AD. In ISS the setting needs to change.
Get Layout file
Create view for index (Currently DP's index is displayed by default)
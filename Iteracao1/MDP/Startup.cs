using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ProjectIteration1.Models;

namespace ProjectIteration1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddDbContext<ProjectContext>(opt => 
                opt.UseInMemoryDatabase("ProjectList"));*/


            /*
            var connection = "Data Source = theDataBase.db";
            services.AddDbContext<ProjectContext>(options => options.UseSqlite(connection));
            */

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.WithOrigins("localhost:4200")
                                 .AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });


            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            /*services.AddDbContext<ProjectContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ProjectContext")));*/


            var connectionString = Configuration.GetConnectionString("ProjectContext");
            services.AddDbContext<ProjectContext>(options =>
                    options.UseSqlServer(connectionString));
        }

         public void Configure(IApplicationBuilder app)
        {
            app.UseCors("AllowAllHeaders");
            app.UseCors(options => options.AllowAnyOrigin());
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}

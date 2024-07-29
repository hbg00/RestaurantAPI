﻿using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;

namespace RestaurantAPI
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
            services.AddDbContext<RestaurantDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("RestaurantDb"));
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}

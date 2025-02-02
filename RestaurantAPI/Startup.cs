﻿using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Repository;
using RestaurantAPI.Seed;

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
            services.AddControllers();
            
            services.AddDbContext<RestaurantDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("RestaurantDb"));
            });
            services.AddScoped<RestaurantSeeder>();

            services.AddAutoMapper(this.GetType().Assembly);

            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RestaurantSeeder seeder)
        {
            seeder.Seed();

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

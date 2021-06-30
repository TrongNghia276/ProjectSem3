using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicServicesWebAPI.Models;
using ClinicServicesWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
namespace ClinicServicesWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ClinicServicesWebAPI.DataConnect.ClinicContext>(options => options.UseSqlServer
               ("Server=tcp:huynguyen.database.windows.net,1433;Initial Catalog=ProjectSem3;Persist Security Info=False;User ID=huy;Password=Luong10000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddScoped<IAccounts, AccountsServices>();
            services.AddScoped<IAppointment, AppointmentServices>();
            services.AddScoped<ICategories, CategoriesServices>();
            services.AddScoped<ICategoryChild, CategoryChildServices>();
            services.AddScoped<IDoctorDetail, DoctorDetailServices>();
            services.AddScoped<IFeedback, FeedbackServices>();
            services.AddScoped<IHealthInformations, HealthInformationsServices>();
            services.AddScoped<IMedicalEquipments, MedicalEquipmentsServices>();
            services.AddScoped<IMedicines, MedicinesServices>();
            services.AddScoped<IOrders, OrdersServices>();
            services.AddScoped<ISeminar, SeminarServices>();
            services.AddScoped<IDoctorA, DoctorAS>();
            services.AddScoped<IvAccApp, vAccAppointService>();
            services.AddScoped<IvAccFeedB, vAccFeedBServices>();
            services.AddScoped<IvAccOrder, vAccOrderServices>();
            services.AddScoped<IvAppointDr, vAppointDrServices>();
            services.AddScoped<IvCateCateChild, vCateCateChildServices>();
            services.AddScoped<IvCateChildMedicine, vCateChildMedicineServices>();
            services.AddScoped<IvCateChildEquipment, vCateChildEquipmentServices>();
            services.AddScoped<IvFeedMedicine, vFeedMedicineServices>();
            services.AddScoped<IvFeedEquipment, vFeedEquipmentServices>();
            services.AddScoped<IvOrderMedicine, vOrderMedicineServices>();
            services.AddScoped<IvOrderEquipment, vOrderEquipmentServices>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddControllers();
           


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

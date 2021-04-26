using InvoiceTracking.BusinessEngine.Contracts;
using InvoiceTracking.BusinessEngine.Implemetation;
using InvoiceTracking.Common.Maps;
using InvoiceTracking.Data.Contracts;
using InvoiceTracking.Data.DataContext;
using InvoiceTracking.Data.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTracking.UI
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
            services.AddRazorPages();
            services.AddDbContext<ZeynepInvoiceTrackingContext>
                (Options => Options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddAutoMapper(typeof(Maps));


            ///services.AddScoped<IInvoiceNumberAllocationRepository, InvoiceNumberAllocationRepository>();
            ///services.AddScoped<IInvoiceNumberRequestRepository, InvoiceNumberRequestRepository>();
            /// services.AddScoped<IInvoiceNumberTypeRepository, InvoiceNumberTypeRepository>();

            services.AddScoped<IInvoiceNumberTypeBusinessEngine, InvoiceNumberTypeBusinessEngine>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCNPJ.Repositories;
using MyCNPJ.RestRequest;
using MyCNPJ.Services;
using MyCNPJ.Services.Company;

namespace MyCNPJ
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
        private string ConnectionString { get; set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Injeção de Dependência
            services.AddTransient<IRestCnpj, RestCnpj>();
            services.AddTransient<ICnpjDataService, CnpjDataService>();
            services.AddScoped<ICreatePdf, CreatePdf>();
            services.AddScoped<ICnpjDataRepository, CnpjDataRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped(a =>
            {
                var dataConext = new DataContext.DataContext(ConnectionString);
                dataConext.Database.EnsureCreated();
                return dataConext;
            });

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

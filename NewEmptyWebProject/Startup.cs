using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewEmptyWebProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewEmptyWebProject
{
    public class Startup
    {
        public IConfiguration Configuraion { get; } //Connectionstringi kullanmak i�in yazd�k
        public Startup(IConfiguration configuration)
        {
            Configuraion = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();//1.ad�m
            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(Configuraion.GetConnectionString("SqlConnection"));//Data klas�r�n� olu�turduktan sonra yapt�k---  appsetting yazd���m�z connection stringi yazd�k i�ie
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); //sertifka Ekledik

            app.UseStaticFiles();//2.ad�m(wwwroot ekledikten sonra) wwwroot gibi statik dosyalar� kullanmak i�in

            app.UseRouting(); //y�nlendirme i�lemleri i�in
            

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapDefaultControllerRoute();//1.yol home index �al��s�n demek sistem otamatik yapar
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller=Home}/{Action=Index}/{id?}"); //Views klas�r�n�n i�erisini ekledikten sonra buray� yapt�k,bundan sonra Identity i�lemleri i�in Identity dosyas�n� indirdim
            });
        }
    }
}

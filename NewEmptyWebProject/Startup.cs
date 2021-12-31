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
        public IConfiguration Configuraion { get; } //Connectionstringi kullanmak için yazdýk
        public Startup(IConfiguration configuration)
        {
            Configuraion = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();//1.adým
            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(Configuraion.GetConnectionString("SqlConnection"));//Data klasörünü oluþturduktan sonra yaptýk---  appsetting yazdýðýmýz connection stringi yazdýk içie
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

            app.UseStaticFiles();//2.adým(wwwroot ekledikten sonra) wwwroot gibi statik dosyalarý kullanmak için

            app.UseRouting(); //yönlendirme iþlemleri için
            

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapDefaultControllerRoute();//1.yol home index çalýþsýn demek sistem otamatik yapar
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller=Home}/{Action=Index}/{id?}"); //Views klasörünün içerisini ekledikten sonra burayý yaptýk,bundan sonra Identity iþlemleri için Identity dosyasýný indirdim
            });
        }
    }
}

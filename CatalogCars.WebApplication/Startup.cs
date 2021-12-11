using CatalogCars.WebApplication.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CatalogCars.WebApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //    options.OnAppendCookie = cookieContext =>
            //      CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            //    options.OnDeleteCookie = cookieContext =>
            //      CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Error/PageNotFound";

                    await next();
                }
            });

            app.UseHttpsRedirection();
            //app.UseCookiePolicy();
            //app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "adminArea", 
                    areaName: "Admin", 
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
            });
        }

        //private void CheckSameSite(HttpContext httpContext, CookieOptions options)
        //{
        //    if (options.SameSite == SameSiteMode.None)
        //    {
        //        var userAgent = httpContext.Request.Headers["User-Agent"].ToString();

        //        if (BrowserDetection.DisallowsSameSiteNone(userAgent))
        //        {
        //            options.SameSite = (SameSiteMode)(-1);
        //        }
        //    }
        //}
    }
}

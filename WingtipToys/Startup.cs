using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessAccessLayer;
using BusinessAccessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WingtipToys.Models;

namespace WingtipToys
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

          

            services.AddDbContext<WingtiptoysContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:WingtipToysDb"]));
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<ICartItemsServices, CartItemsServices>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IOrderDetailsServices, OrderDetailsServices>();
            services.AddScoped<IProductsServices, ProductsServices>();
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            

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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            AutoMapper.Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<CartItems, CartItemsDto>().ReverseMap();
                mapper.CreateMap<Categories, CategoriesDto>().ReverseMap();
                mapper.CreateMap<OrderDetails, OrderDetailsDto>().ReverseMap();
                mapper.CreateMap<Orders, OrdersDto>().ReverseMap();
                mapper.CreateMap<Products, ProductsDto>().ReverseMap();
                
            });
        }
    }
}

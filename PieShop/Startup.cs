using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PieShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PieShop
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
            services.AddDbContext<PieShopContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PieShopContext")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<PieShopContext>();

            // We use the Transient to instantiate a singleton of our
            // Service the AddTransient in services will return a Service everytime
            // a Repository is called
            services.AddTransient<IPieRepository, PieService>();
            services.AddTransient<ICustomerRepository, CustomerService>();
            services.AddTransient<IPurchaseRepository, PurchaseService>();
            services.AddMvc();
            services.AddSession();

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

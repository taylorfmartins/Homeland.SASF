using Homeland.SASF.Model;
using Homeland.SASF.Persistencia;
using Homeland.SASF.Security;
using Homeland.SASF.WebApp.HttpClients;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homeland.SASF.WebApp
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

            services.AddDbContext<SASFContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("SASF"));
            });

            services.AddDbContext<AuthDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("AuthDB"));
            });

            services.AddIdentity<Usuario, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<AuthDbContext>();

            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/Usuario/Login";
            });

            services.AddTransient<IRepository<Funcionario>, RepositorioBaseEF<Funcionario>>();
            services.AddTransient<IRepository<Setor>, RepositorioBaseEF<Setor>>();
            services.AddTransient<IRepository<PetPerfeito>, RepositorioBaseEF<PetPerfeito>>();
            services.AddTransient<IRepository<Ocorrencia>, RepositorioBaseEF<Ocorrencia>>();

            services.AddHttpClient<NotificationApiClient>(client =>
            {
                client.BaseAddress = new Uri("http://192.168.15.22:4000/notification/Notification/Send");
            });
            services.AddHttpClient<PetPerfeitoApiClient>(client =>
            {
                client.BaseAddress = new Uri("http://petperfeito.kinghost.net/view/api.php?senha=e23e434r5443e33ee3e22");
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

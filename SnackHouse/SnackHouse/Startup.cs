using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using SnackHouse.Data;
using SnackHouse.Repositories;
using SnackHouse.Models;
using Microsoft.AspNetCore.Identity;

namespace SnackHouse
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
            services.AddIdentity<IdentityUser, IdentityRole>() //Adiciona o sistema Identiy padrão para os tipos de perfis especificados
                .AddEntityFrameworkStores<SnackHouseDbContext>() //Adiciona uma implementação do EntityFramework que armazena as informações de identidade
                .AddDefaultTokenProviders(); //Inclui os tokens para troca de senha e envio de e-mail

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //Informando a classe DBCONtext utilizada e o provedor do banco
            services.AddDbContext<SnackHouseDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISnackRepository, SnackRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            //Para ter acesso a sessão no contexto
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(shoppingCart => ShoppingCart.GetShoppingCart(shoppingCart));

            services.AddMemoryCache();
            services.AddSession();//incluir o serviço de sessão no estado da aplicação
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
            app.UseSession();//Ativando o uso da session

            app.UseRouting();

            app.UseAuthentication(); //Midleware que adiciona a autenticação ao pipeline da solicitação
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "AdminArea",
                    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "filterByCategory",
                    pattern: "{controller=Snacks}/{action=List}/{categoryName?}",
                    defaults: new {Controller="Snacks", action="List"}
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                
            });
        }
    }
}

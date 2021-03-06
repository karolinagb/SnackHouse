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
using ReflectionIT.Mvc.Paging;
using SnackHouse.Areas.Admin.Services;

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
            services.AddIdentity<IdentityUser, IdentityRole>() //Adiciona o sistema Identiy padr�o para os tipos de perfis especificados
                .AddEntityFrameworkStores<SnackHouseDbContext>() //Adiciona uma implementa��o do EntityFramework que armazena as informa��es de identidade
                .AddDefaultTokenProviders(); //Inclui os tokens para troca de senha e envio de e-mail

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //Informando a classe DBCONtext utilizada e o provedor do banco
            services.AddDbContext<SnackHouseDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISnackRepository, SnackRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            //Para ter acesso a sess�o no contexto
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(shoppingCart => ShoppingCart.GetShoppingCart(shoppingCart));

            //Quando acontecer o erro 403 ele vai redirecionar para o caminho definido aqui
            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Home/AccessDenied");

            services.AddScoped<SalesReportService>();

            services.AddMemoryCache();
            services.AddSession();//incluir o servi�o de sess�o no estado da aplica��o

            //Adicionando servi�o de pagina��o e filtro ao projeto
            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "pageindex";
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
            app.UseSession();//Ativando o uso da session

            app.UseRouting();

            app.UseAuthentication(); //Midleware que adiciona a autentica��o ao pipeline da solicita��o
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

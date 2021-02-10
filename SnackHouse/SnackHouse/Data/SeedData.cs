using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace SnackHouse.Data
{
    //static = não é necessário criar instância da classe
    public static class SeedData
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            //Incluir perfis customizados

            //Instância para permitir gerenciar os perfis:
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //Instância para gerenciar os usuários:
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //Define os perfis em um array de strings
            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;

            //percorre o array de strings
            //verifica se o perfil já existe
            foreach(var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //cria perfis e os inclui no banco de dados
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //cria um super usuário que pode manter a aplicação web
            var powerUser = new IdentityUser
            {
                //obtém o nome e o email do arquivo de configuração
                UserName = configuration.GetSection("UserSettings")["UserName"],
                Email = configuration.GetSection("UserSettings")["UserEmail"]
            };

            //obtém a senha do arquivo de configuração
            var userPassword = configuration.GetSection("UserSettings")["UserPassword"];

            //verifica se existe um usuário com o email informado
            var user = await userManager.FindByEmailAsync(configuration.GetSection("UserSettings")["UserEmail"]);

            if(user == null)
            {
                //cria o super usuário com os dados informados
                var createPowerUser = await userManager.CreateAsync(powerUser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    //atribui o usuário ao perfil Admin
                    await userManager.AddToRoleAsync(powerUser, "Admin");
                }
            }
        }
    }
}

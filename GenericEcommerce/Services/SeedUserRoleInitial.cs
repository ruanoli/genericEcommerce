using GenericEcommerce.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GenericEcommerce.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Se não existir o perfil, eu crio.
        /// </summary>
        public void SeedRoles()
        {

            if (!_roleManager.RoleExistsAsync("Membro").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Membro";
                role.NormalizedName = "MEMBRO";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        /// <summary>
        /// Cria os Usuários e atribui os perfis aos usuários
        /// </summary>
        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("user@localhost").Result == null)
            {
                IdentityUser identityUser = new IdentityUser();
                identityUser.UserName = "user@localhost";
                identityUser.Email = "user@localhost";
                identityUser.NormalizedUserName = "USER@LOCALHOST";
                identityUser.NormalizedEmail = "USER@LOCALHOST";
                identityUser.EmailConfirmed = true;
                identityUser.LockoutEnabled = false;
                identityUser.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(identityUser, "Teste@1234").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(identityUser, "Member").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                IdentityUser identityUser = new IdentityUser();
                identityUser.UserName = "admin@localhost";
                identityUser.Email = "admin@localhost";
                identityUser.NormalizedUserName = "ADMIN@LOCALHOST";
                identityUser.NormalizedEmail = "ADMIN@LOCALHOST";
                identityUser.EmailConfirmed = true;
                identityUser.LockoutEnabled = false;
                identityUser.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(identityUser, "Admin@1234").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(identityUser, "Admin").Wait();
                }
            }

        }
    }
}

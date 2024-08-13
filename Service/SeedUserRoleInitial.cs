using Microsoft.AspNetCore.Identity;

namespace SistemaDeGestao.Service
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

        public async Task SeedRolesAsync()
        {
            if (!await _roleManager.RoleExistsAsync("Vendedor"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Vendedor";
                role.NormalizedName = "VENDEDOR";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult roleResult = await _roleManager.CreateAsync(role);
            }

            if (!await _roleManager.RoleExistsAsync("Gerente"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Gerente";
                role.NormalizedName = "GERENTE";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult roleResult = await _roleManager.CreateAsync(role);
            }

            if (!await _roleManager.RoleExistsAsync("Administrador"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrador";
                role.NormalizedName = "ADMINISTRADOR";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult roleResult = await _roleManager.CreateAsync(role);
            }
        }

        public async Task SeedUserAsync()
        {
            if (await _userManager.FindByEmailAsync("vendedor@localhost") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "vendedor@localhost";
                user.Email = "vendedor@localhost";
                user.NormalizedUserName = "VENDEDOR@LOCALHOST";
                user.NormalizedEmail = "VENDEDOR@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, "123@mudar");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Vendedor");
                }
            }
            if (await _userManager.FindByEmailAsync("gerente@localhost") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "gerente@localhost";
                user.Email = "gerente@localhost";
                user.NormalizedUserName = "GERENTE@LOCALHOST";
                user.NormalizedEmail = "GERENTE@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, "123@mudar");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Gerente");
                }
            }
            if (await _userManager.FindByEmailAsync("admin@localhost") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, "123@mudar");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Administrador");
                }
            }
            
        }   
    }
}

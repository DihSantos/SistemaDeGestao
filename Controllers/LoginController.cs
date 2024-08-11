using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestao.Helper;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaDeGestao.Controllers
{ 
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S.I_AgenciaViajes.Contexto;
using S.I_AgenciaViajes.Models;
using SQLitePCL;
using System.Security.Claims;

namespace S.I_AgenciaViajes.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyContext _context;
        public LoginController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Administrador"))
                {
                    return RedirectToAction("Index", "Administrador");
                }
                else
                {
                    return RedirectToAction("Index", "Recepcionista");
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(string email, string password) 
        {
            var usuario = await _context.Usuarios
                .Where(x => x.Email == email && x.Password == password)
                .FirstOrDefaultAsync();
            if (usuario == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                await SetUserCookie(usuario);
                if(usuario.Cargo == Dto.CargoEnum.Administrador) 
                {
                return RedirectToAction("Index", "Administrador");
                }
                else
                {
                    return RedirectToAction("Index", "Recepcionista");
                }
            }
        }
        private async Task SetUserCookie(Usuario usuario)
        {
            var claims = new List<Claim>()
               {
               new Claim(ClaimTypes.Name, usuario!.Nombre!),
               new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
               new Claim(ClaimTypes.Role, usuario!.Cargo!.ToString())
                };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity))
;
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
        
    }
}

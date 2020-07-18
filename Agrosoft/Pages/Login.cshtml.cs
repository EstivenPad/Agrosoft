using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Agrosoft.BLL;
using Agrosoft.DAL;
using Agrosoft.Models;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agrosoft.Pages
{
    public class LoginModel : PageModel
    {
        IToastService toast;
        public static int UsuarioId;
        Usuarios Usuarios = new Usuarios();
        List<Usuarios> ListaUsuarios = new List<Usuarios>();
        Contexto db = new Contexto();

        public async Task<ActionResult> OnGetAsync(string paramUsername, string paramPassword)
        {
            string returnUrl = Url.Content("/LogInPage");

            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch
            {
                throw;
            }

            if (UsuariosBLL.ComprobarDatosUsuario(paramUsername, paramPassword))
            {
                UsuarioId = db.Usuarios.Where(A => A.NombreUsuario.Equals(paramUsername)).Select(A => A.UsuarioId).FirstOrDefault();
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, paramUsername),
                    new Claim(ClaimTypes.Role, UsuariosBLL.GetTipoUsuario(paramUsername)),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value
                };
                try
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
                }
                catch (Exception)
                {
                    throw;
                }
                return LocalRedirect("/");
            }
            else if (!UsuariosBLL.ComprobarDatosUsuario(paramUsername, paramPassword))
            {
                return LocalRedirect("/UserNotExist");
            }
            else
            {
                return LocalRedirect(returnUrl);
            }
        }
    }
}

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
        Usuarios Usuarios = new Usuarios();
        List<Usuarios> ListaUsuarios = new List<Usuarios>();
        Contexto db = new Contexto();

        public async Task<ActionResult> OnGetAsync(string Usuario, string Clave)
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

            if (UsuariosBLL.ComprobarDatosUsuario(Usuario, Clave))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Usuario),
                    new Claim(ClaimTypes.Role, UsuariosBLL.GetTipoUsuario(Usuario)),
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
            else if (!UsuariosBLL.ComprobarDatosUsuario(Usuario, Clave))
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

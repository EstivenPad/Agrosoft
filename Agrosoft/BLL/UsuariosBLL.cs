using Agrosoft.DAL;
using Agrosoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agrosoft.BLL
{
    public class UsuariosBLL : RepositorioBase<Usuarios>
    {
        public override bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Usuarios.Any(x => x.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }

        public override bool Insertar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                usuarios.ClaveUsuario = Encriptar(usuarios.ClaveUsuario);
                usuarios.ClaveConfirmada = Encriptar(usuarios.ClaveConfirmada);

                db.Usuarios.Add(usuarios);
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public override bool Modificar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                usuarios.ClaveUsuario = Encriptar(usuarios.ClaveUsuario);
                usuarios.ClaveConfirmada = Encriptar(usuarios.ClaveConfirmada);

                db.Entry(usuarios).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var usuario = db.Usuarios.Find(id);

                if (usuario != null)
                {
                    db.Usuarios.Remove(usuario);
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public override Usuarios Buscar(int id)
        {
            Usuarios usuarios = new Usuarios();
            Contexto db = new Contexto();

            try
            {
                usuarios = db.Usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return usuarios;
        }

        public static bool ExistenciaUsuario(int id)
        {
            bool existe = false;
            Contexto db = new Contexto();

            try
            {
                existe = db.Usuarios.Any(x => x.UsuarioId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return existe;
        }

        public static bool ComprobarDatosUsuario(string NombreUsuario, string clave)
        {
            bool paso = false;
            Contexto db = new Contexto();
       
            try
            {
               paso = db.Usuarios.Any(x => x.NombreUsuario == NombreUsuario && x.ClaveUsuario == clave);
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static string GetTipoUsuario(string Usuario)
        {
            string nivel;
            Contexto db = new Contexto();

            try
            {
                nivel = db.Usuarios.Where(A => A.NombreUsuario.Equals(Usuario)).Select(A => A.TipoUsuario).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return nivel;
        }

        public static string Encriptar(string cadenaEncriptada)
        {
            if (!string.IsNullOrEmpty(cadenaEncriptada))
            {
                string resultado = string.Empty;
                byte[] encryted = Encoding.Unicode.GetBytes(cadenaEncriptada);
                resultado = Convert.ToBase64String(encryted);

                return resultado;
            }

            return string.Empty;
        }

        public static string Desencriptar(string cadenaDesencriptada)
        {
            if (!string.IsNullOrEmpty(cadenaDesencriptada))
            {
                string resultado = string.Empty;
                byte[] decryted = Convert.FromBase64String(cadenaDesencriptada);
                resultado = System.Text.Encoding.Unicode.GetString(decryted);

                return resultado;
            }

            return string.Empty;
        }
    }
}

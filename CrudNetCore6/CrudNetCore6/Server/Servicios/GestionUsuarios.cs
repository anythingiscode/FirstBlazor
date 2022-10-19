using CrudNetCore6.Server.Modelos;
using CrudNetCore6.Shared;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CrudNetCore6.Server.Servicios
{
    public class GestionUsuarios : IUsuario
    {
        readonly NetCore6EjemploContext dbContext = new(); // Este obj de la clase que creamos en Modelos y que contiene la conexion de .json que creamos 

        // Creamos el constructor   --> min 8  del 2/6
        public GestionUsuarios(NetCore6EjemploContext db)
        {
            dbContext = db;
        }

        public void ActualizarUsuario(Usuario u)
        {
            try
            {
                dbContext.Entry(u).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void BorrarUsuario(int id)
        {
            try
            {
                Usuario? u = dbContext.Usuarios.Find(id);   //? para que acepte nulos en caso de que no lo encuentre
                if (u != null)
                {
                    dbContext.Usuarios.Remove(u);            //Si encuentro el usuario se borra
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();             // si no, lanzo una excepcion de Null
                }
                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario DatosUsuario(int id)     
        {
            try
            {
                Usuario? u = dbContext.Usuarios.Find(id);   //? para que acepte nulos en caso de que no lo encuentre
                if (u != null) return u;            //Si encuentro el usuario lo devuelvo
                else throw new ArgumentNullException();             // si no, lanzo una excepcion de Null
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Usuario> DatosUsuarios()        // Devolverá una lista de usuarios
        {
            try
            {
                return dbContext.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void NuevoUsuario(Usuario u)
        {
            try
            {
                u.FechaAlta = DateTime.Now;
                dbContext.Usuarios.Add(u);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using CrudNetCore6.Shared;

namespace CrudNetCore6.Server.Servicios
{
    public interface IUsuario
    {
        public List<Usuario> DatosUsuarios();

        public void NuevoUsuario(Usuario u);

        public void ActualizarUsuario(Usuario u);

        public Usuario DatosUsuario(int id);

        public void BorrarUsuario(int id);
    }
}

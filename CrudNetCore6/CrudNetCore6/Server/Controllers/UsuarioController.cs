using CrudNetCore6.Server.Servicios;
using CrudNetCore6.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudNetCore6.Server.Controllers
{
    [Route("api/[controller]")]     // Punto de entrada == api/"Nombre del controlador"
    //[Route("api/usuario")]       Tambien se puede personalizar la ruta
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario iUsuario;
        //Constructor
        public UsuarioController(IUsuario iUser)
        {
            iUsuario = iUser;
        }

        [HttpGet]           //Método que devuelve la lista de usuarios
        public async Task<List<Usuario>> ListaUsuarios()
        {
            return await Task.FromResult(iUsuario.DatosUsuarios());
        }

        [HttpPost]                          // Mét Post para cuando NuevoUsuario tenga un id==0 min 7'40
        public void Post(Usuario u)
        {
            iUsuario.NuevoUsuario(u);
        }

        [HttpGet("{Id}")]
        public IActionResult DameUsuario(int id)
        {
            Usuario u = iUsuario.DatosUsuario(id);
            if (u != null)      //Si no hay usuario
                return Ok(u);
            else
                return NotFound();
        }

        [HttpPut]
        public void Modificar(Usuario u)
        {
            iUsuario.ActualizarUsuario(u);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            iUsuario.BorrarUsuario(id);
            return Ok();
        }
    }
}

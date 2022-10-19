using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceBlazorCrudHDL.Models;
using WebServiceBlazorCrudHDL.Models.Request;
using WebServiceBlazorCrudHDL.Models.Response;

namespace WebServiceBlazorCrudHDL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CervezaController : ControllerBase
    {
        [HttpGet]                   // Este parámetro indica que solo podré ingresar con el protocolo HttpGet
        public IActionResult Get()          // IActionResult es una interface que sirve para retornar contenido
        {
            Respuesta oRespuesta = new Respuesta();     //Usaremos este obj para devolver la respuesta

            try         //ponemos el using dentro de try-catch por si hubiese un error y controlarlo
            {
                using (BlazorCrudHDLContext db = new BlazorCrudHDLContext())    //Creo el obj db
                {
                    var lst = db.Cerveza.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;

                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            

                return Ok(oRespuesta);  //El mét OK es nativo de .NetCore sirve para devolver obj como json
        }

        // ********   INSERTAR :      ********

        [HttpPost]
        public IActionResult Add(CervezaRequest model)     //Decimos que la consulta que pasamos se llama "model"    
        {
            Respuesta oRespuesta = new Respuesta();    

            try         
            {
                using (BlazorCrudHDLContext db = new BlazorCrudHDLContext())   
                {
                    Cerveza oCerveza = new Cerveza();
                    oCerveza.Marca = model.Marca;
                    oCerveza.Nombre = model.Nombre;     //Ojo!! Aqui traemos los datos. A continuación hay que insertarlos
                    db.Cerveza.Add(oCerveza);           //Añadimos
                    db.SaveChanges();                   //Guardamos cambios
                    oRespuesta.Exito = 1;               // Devolvemos nuestro ctrl de respuesta a 1 == Exito
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);  //El mét OK es nativo de .NetCore sirve para devolver obj como json
        }


        // ********   EDITAR :      ********

        [HttpPut]
        public IActionResult Edit(CervezaRequest model)     //Decimos que la consulta que pasamos se llama "model"    
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (BlazorCrudHDLContext db = new BlazorCrudHDLContext())
                {
                    Cerveza oCerveza = db.Cerveza.Find(model.Id);       //En lugar de crear un objeto (como INSERT) vamos a buscar el que nos envian
                    oCerveza.Marca = model.Marca;
                    oCerveza.Nombre = model.Nombre;     
                    db.Entry(oCerveza).State=Microsoft.EntityFrameworkCore.EntityState.Modified;    //Indicamos a Entity que este obj se modifico       
                    db.SaveChanges();                   
                    oRespuesta.Exito = 1;               
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);  //El mét OK es nativo de .NetCore sirve para devolver obj como json
        }

        // ********   ELIMINAR :      ********

        [HttpDelete("{Id}")]            //tenemos que especificar que atributo va a recibir
        public IActionResult Delete(int Id)     //Solo pasamos el atributo que va a identificar el objeto    
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (BlazorCrudHDLContext db = new BlazorCrudHDLContext())
                {
                    Cerveza oCerveza = db.Cerveza.Find(Id);       //El Find solo recibe la var Id que le pasamos al mét
                    db.Remove(oCerveza);           
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);  //El mét OK es nativo de .NetCore sirve para devolver obj como json
        }
    }
}

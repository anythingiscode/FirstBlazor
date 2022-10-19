namespace BlazorCrudHDL.Data
{
    public class RespuestaBlz
    {
        public int Exito { get; set; }      //Ctrl de la respuesta de la conexion

        public string Mensaje { get; set; } //Msg en caso de que haya un error...o exito

        public object Data { get; set; }    // Un objeto para contener datos. Todas las clases heredan de "object" y podemos poner cualquier cosa
    }
}

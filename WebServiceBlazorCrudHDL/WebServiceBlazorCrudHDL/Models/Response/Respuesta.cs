namespace WebServiceBlazorCrudHDL.Models.Response
{
    public class Respuesta
    {
        public int Exito { get; set; }      //Ctrl de la respuesta de la conexion

        public string Mensaje { get; set; } //Msg en caso de que haya un error...o exito

        public object Data { get; set; }    // Un objeto para contener datos. Todas las clases heredan de "object" y podemos poner cualquier cosa

        //Constructor.... solo para decir que por defecto Exito=0
        public Respuesta()
        {
            Exito =0;
        }
    }
}

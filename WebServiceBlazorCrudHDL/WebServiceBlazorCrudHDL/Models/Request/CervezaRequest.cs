namespace WebServiceBlazorCrudHDL.Models.Request
{
    public class CervezaRequest     // recibirá los obj que vamos a insertar --> Inicializo con los campos de la BDD
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }    
        public string Marca { get; set; }
    }
}

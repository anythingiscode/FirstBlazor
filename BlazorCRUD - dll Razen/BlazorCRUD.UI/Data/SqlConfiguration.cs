using System.Data.Common;

namespace BlazorCRUD.UI.Data
{
    public class SqlConfiguration
    {
        // Usamos esta clase para traer la ConnectionString desde el .json a nuestro servicio
        // Para ello creamos el constructor:
        public SqlConfiguration(string connextionString) => ConnectionString = connextionString;
        public string ConnectionString { get;  }
    }
}

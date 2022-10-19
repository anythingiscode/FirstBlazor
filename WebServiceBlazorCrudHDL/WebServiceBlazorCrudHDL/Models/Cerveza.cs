using System;
using System.Collections.Generic;

namespace WebServiceBlazorCrudHDL.Models
{
    public partial class Cerveza
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Marca { get; set; } = null!;
    }
}

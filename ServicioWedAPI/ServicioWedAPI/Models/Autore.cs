using System;
using System.Collections.Generic;

#nullable disable

namespace ServicioWedAPI.Models
{
    public partial class Autore
    {
        public int CodAutor { get; set; }
        public string NomAutor { get; set; }
        public int? CodPais { get; set; }
        public string EmailAutor { get; set; }
        public DateTime? FecNacAut { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ServicioWedAPI.Models
{
    public partial class Libro
    {
        public int CodLibro { get; set; }
        public string NomLibro { get; set; }
        public decimal? PreLibro { get; set; }
        public int? StkLibro { get; set; }
        public int? Edicion { get; set; }
        public int? Estado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioWedAPI.Entidades
{
    public class ConsultaporAutor
    {
        public int idAutor { get; set; }
        public int idLibro { get; set; }
        public string libro { get; set; }
        public int? edicion { get; set; }
        public Decimal? precio { get; set; }
        public int? stock { get; set; }
        public Decimal? importe { get; set; }
    }
}

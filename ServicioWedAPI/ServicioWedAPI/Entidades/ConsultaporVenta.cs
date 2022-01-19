using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioWedAPI.Entidades
{
    public class ConsultaporVenta
    {
        public int id_venta { get; set; }
        public int id_libro { get; set; }
        public string libro { get; set; }
        public int cantidad { get; set; }
        public Decimal? precio { get; set; }
        public Decimal? total { get; set; }
    }
}

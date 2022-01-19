using System;
using System.Collections.Generic;

#nullable disable

namespace ServicioWedAPI.Models
{
    public partial class DetPedido
    {
        public int NumVta { get; set; }
        public int CodLibro { get; set; }
        public short Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }

        public virtual CabPedido NumVtaNavigation { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ServicioWedAPI.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            CabPedidos = new HashSet<CabPedido>();
        }

        public string CodCli { get; set; }
        public string NomCli { get; set; }
        public int? CodPais { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<CabPedido> CabPedidos { get; set; }
    }
}

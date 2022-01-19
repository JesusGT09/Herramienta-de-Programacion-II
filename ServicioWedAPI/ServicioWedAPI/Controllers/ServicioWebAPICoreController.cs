using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicioWedAPI.Entidades;
using ServicioWedAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicioWedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioWebAPICoreController : ControllerBase
    {
        BDVENTALIBROSContext db = new BDVENTALIBROSContext();

        [HttpGet("VentaporLibros")]
        public IEnumerable<ConsultaporVenta> VentaporLibros()
        {
            IEnumerable<ConsultaporVenta> query = (from dep in db.DetPedidos
                                                 join li in db.Libros on dep.CodLibro equals li.CodLibro
                                                 select new ConsultaporVenta
                                                 {
                                                     id_venta = dep.NumVta,
                                                     id_libro = dep.CodLibro,
                                                     libro = li.NomLibro,
                                                     cantidad = dep.Cantidad,
                                                     precio = dep.Precio,
                                                     total = dep.Precio * dep.Cantidad
                                                 }).ToList();

            return query;
        }

        [HttpGet("VentaporLibrosId/{id_venta}")]
        public IEnumerable<ConsultaporVenta> VentaporLibrosId(int id_venta)
        {
            IEnumerable<ConsultaporVenta> query = (from dep in db.DetPedidos
                                                 join li in db.Libros on dep.CodLibro equals li.CodLibro
                                                 where dep.NumVta.Equals(id_venta)
                                                 select new ConsultaporVenta
                                                 {
                                                     id_venta = dep.NumVta,
                                                     id_libro = dep.CodLibro,
                                                     libro = li.NomLibro,
                                                     cantidad = dep.Cantidad,
                                                     precio = dep.Precio,
                                                     total = dep.Precio * dep.Cantidad
                                                 }).ToList();

            return query;
        }


        [HttpGet("AutoresporLibro/{id}")]
        public IEnumerable<ConsultaporAutor> AutoresporLibro(int id)
        {
            IEnumerable<ConsultaporAutor> query = (from al in db.LibrosAutores
                                                 join li in db.Libros on al.CodLibro equals li.CodLibro
                                                 where al.CodAutor.Equals(id)
                                                 select new ConsultaporAutor
                                                 {
                                                     idAutor = al.CodAutor,
                                                     idLibro = al.CodLibro,
                                                     libro = li.NomLibro,
                                                     edicion = li.Edicion,
                                                     precio = li.PreLibro,
                                                     stock = li.StkLibro,
                                                     importe = li.PreLibro * li.StkLibro
                                                 }).ToList();

            return query;

        }
        [HttpGet("ListarAutores")]
        public IEnumerable<Autore> ListarAutores()
        {
            return db.Autores.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Inventario.Models
{
    [Table("Factura")]
    public class Factura
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey(typeof(Producto))]
        public int ProductoId { get; set; }

        public Factura()
        {
        }

        public Factura(string descripcion, int cantidad)
        {
            Descripcion = descripcion;
            Cantidad = cantidad;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Inventario.Models
{
    [Table("Compra")]
    public class Compra
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey(typeof(Producto))]
        public int ProductoId { get; set; }

        public Compra()
        {
        }

        public Compra(string descripcion, int cantidad)
        {
            Descripcion = descripcion;
            Cantidad = cantidad;
        }
    }
}

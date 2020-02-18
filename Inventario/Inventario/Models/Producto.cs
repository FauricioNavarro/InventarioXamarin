using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Inventario.Models
{ 
    [Table("Producto")]
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Existencias { get; set; }
        public bool Estado { get; set; }

        [OneToMany]
        public List<Compra> Compras { get; set; }

        [OneToMany]
        public List<Factura> Facturas { get; set; }

        public Producto() { }

        public Producto(string codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
            Existencias = 0;
            Estado = true;
            Compras = new List<Compra>();
            Facturas = new List<Factura>();
        }
    }
}

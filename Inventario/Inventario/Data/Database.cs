using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Inventario.Models;

namespace Inventario.Datos
{
    public class Database
    {
        SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<Producto>().Wait();
            _database.CreateTableAsync<Compra>().Wait();
            _database.CreateTableAsync<Factura>().Wait();
        }

        public Task<List<Producto>> GetProductosAsync()
        {
            try
            {
                return _database.Table<Producto>()
                    //.Where(x => x.Estado == true)
                    .ToListAsync();


            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public Task<int> AddProductoAsync(Producto producto)
        {
            try
            {
                return _database.InsertAsync(producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public Task<int> DeleteProductoAsync(Producto producto)
        {
            try
            {
                return _database.DeleteAsync(producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public Task<int> EditProductoAsync(Producto producto)
        {
            try
            {
                return _database.UpdateAsync(producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<int> ComprarProductoAsync(int productoId,Compra compra)
        {
            try
            {
                Producto productoTemp = await _database.Table<Producto>()                    
                    .Where(c => c.Id == productoId)
                    .FirstOrDefaultAsync();
                compra.Fecha = DateTime.Now;
                compra.ProductoId = productoId;
                var respuesta = await _database.InsertAsync(compra);
                if (respuesta == 1)
                {
                    productoTemp.Existencias = productoTemp.Existencias + compra.Cantidad;
                    if (productoTemp.Compras == null)
                    {
                        productoTemp.Compras = new List<Compra>();
                    }
                    productoTemp.Compras.Add(compra);
                    int i = await _database.UpdateAsync(productoTemp);
                    return i;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<Producto> FindProductoAsync(int productoId)
        {
            try
            {
                Producto productoTemp = await _database.Table<Producto>().Where(c => c.Id == productoId).FirstOrDefaultAsync();
                return productoTemp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public Task<List<Compra>> GetComprasAsync()
        {
            try
            {
                return _database.Table<Compra>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<int> FacturarProductoAsync(int productoId, Factura factura)
        {
            try
            {
                Producto productoTemp = await _database.Table<Producto>()
                    .Where(c => c.Id == productoId)
                    .FirstOrDefaultAsync();

                factura.Fecha = DateTime.Now;
                factura.ProductoId = productoId;
                var respuesta = await _database.InsertAsync(factura);
                if (respuesta == 1)
                {
                    productoTemp.Existencias = productoTemp.Existencias - factura.Cantidad;
                    if (productoTemp.Facturas == null)
                    {
                        productoTemp.Facturas = new List<Factura>();
                    }
                    productoTemp.Facturas.Add(factura);
                    int i = await _database.UpdateAsync(productoTemp);
                    return i;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public Task<List<Factura>> GetFacturasAsync()
        {
            try
            {
                return _database.Table<Factura>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}

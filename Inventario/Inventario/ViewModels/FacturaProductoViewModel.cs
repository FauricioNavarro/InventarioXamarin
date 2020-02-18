using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventario.Models;

namespace Inventario.ViewModels
{
	public class FacturaProductoViewModel : ViewModelBase
	{
        private Producto productoAux = new Producto();

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { SetProperty(ref _descripcion, value); }
        }

        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set { SetProperty(ref _cantidad, value); }
        }

        private DelegateCommand _facturarProducto;
        public DelegateCommand FacturarProducto
        {
            get { return _facturarProducto; }
            set { SetProperty(ref _facturarProducto, value); }
        }

        public FacturaProductoViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            FacturarProducto = new DelegateCommand(EjecutarFacturaProducto);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            productoAux = (Producto)parameters["productoSeleccionado"];
        }        

        protected async void EjecutarFacturaProducto()
        {
            Factura factura = new Factura(Descripcion, Cantidad);
            await App.Database.FacturarProductoAsync(productoAux.Id, factura);

            await NavigationService.GoBackAsync();
        }        
    }
}

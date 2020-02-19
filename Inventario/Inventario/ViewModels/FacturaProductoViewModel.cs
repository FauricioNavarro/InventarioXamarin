using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventario.Models;
using Inventario.Resx;

namespace Inventario.ViewModels
{
	public class FacturaProductoViewModel : ViewModelBase
	{
        private IPageDialogService _pageDialogService { get; set; }
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

        public FacturaProductoViewModel(INavigationService navigationService,IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            FacturarProducto = new DelegateCommand(EjecutarFacturaProducto);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            productoAux = (Producto)parameters["productoSeleccionado"];
        }        

        protected async void EjecutarFacturaProducto()
        {
            Factura factura = new Factura(Descripcion, Cantidad);

            if(Cantidad > 0)
            {
                await App.Database.FacturarProductoAsync(productoAux.Id, factura);
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync(AppResources.EtiquetaError, AppResources.ErrorCantidad, AppResources.EtiquetaOk);
            }            
            await NavigationService.GoBackAsync();
        }        
    }
}

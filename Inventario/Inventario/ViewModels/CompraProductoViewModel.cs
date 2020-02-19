using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventario.Models;
using Prism.Services;
using Inventario.Resx;

namespace Inventario.ViewModels
{
	public class CompraProductoViewModel : ViewModelBase
	{
        #region Párametros
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

        private DelegateCommand _comprarProducto;
        public DelegateCommand ComprarProducto
        {
            get { return _comprarProducto; }
            set { SetProperty(ref _comprarProducto, value); }
        }
        #endregion

        #region Constructor
        public CompraProductoViewModel(INavigationService navigationService,IPageDialogService pageDialogService)
            :base(navigationService)
        {
            _pageDialogService = pageDialogService;
            ComprarProducto = new DelegateCommand(EjecutarComprarProducto);
        }
        #endregion

        #region Metodos
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            productoAux = (Producto)parameters["productoSeleccionado"];
        }

        protected async void EjecutarComprarProducto()
        {
            Compra compra = new Compra(Descripcion,Cantidad);
            if (Descripcion != null && Cantidad > 0 && !Descripcion.Equals("") && !Cantidad.Equals(""))
            {
                await App.Database.ComprarProductoAsync(productoAux.Id, compra);
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync(AppResources.EtiquetaError, AppResources.ErrorCantidad, AppResources.EtiquetaOk);
            }
            await NavigationService.GoBackAsync();
        }
        #endregion
    }
}

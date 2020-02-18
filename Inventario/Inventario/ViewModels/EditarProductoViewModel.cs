using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Inventario.Models;
using Prism.Services;
using Inventario.Utils;

namespace Inventario.ViewModels
{
	public class EditarProductoViewModel : ViewModelBase
	{
        #region Parámetros
        private IPageDialogService _pageDialogService { get; set; }

        private Producto _producto = new Producto();
        public Producto Producto
        {
            get { return _producto; }
            set { SetProperty(ref _producto, value); }
        }

        private DelegateCommand _editarProducto;
        public DelegateCommand EditarProducto
        {
            get { return _editarProducto; }
            set { SetProperty(ref _editarProducto, value); }
        }
        #endregion

        #region Constructor
        public EditarProductoViewModel(INavigationService navigationService,IPageDialogService pageDialogService)
            :base(navigationService)
        {
            _pageDialogService = pageDialogService;
            EditarProducto = new DelegateCommand(EjecutaEditarProducto);
        }
        #endregion

        #region Métodos
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Producto = (Producto)parameters["productoSeleccionado"];
        }

        protected async void EjecutaEditarProducto()
        {
            if (Producto.Nombre != null && Producto.Codigo != null && !Producto.Nombre.Equals("") && !Producto.Codigo.Equals(""))
            {
                var response = await App.Database.EditProductoAsync(Producto);
                await NavigationService.GoBackAsync();
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync(Mensajes.tituloError, Mensajes.errorEditarProducto, Mensajes.respuestaOk);
            }
        }
        #endregion
    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Inventario.Models;
using Prism.Services;
using Inventario.Resx;


namespace Inventario.ViewModels
{
	public class AgregarProductoViewModel : ViewModelBase
	{
        #region Parámetros
        private IPageDialogService _pageDialogService { get; set; }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private string _codigo;
        public string Codigo
        {
            get { return _codigo;}
            set { SetProperty(ref _codigo, value); }
        }

        private DelegateCommand _agregarProducto;
        public DelegateCommand AgregarProducto
        {
            get { return _agregarProducto; }
            set { SetProperty(ref _agregarProducto, value); }
        }
        
        #endregion

        #region Constructor
        public AgregarProductoViewModel(INavigationService navigationService,IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            AgregarProducto = new DelegateCommand(EjecutaAgregarProducto);
            AgregarProducto.ObservesProperty(()=> Nombre);
            AgregarProducto.ObservesProperty(()=> Codigo);
        }
        #endregion

        #region Métodos
        protected async void EjecutaAgregarProducto()
        {
            if(Nombre != null && Codigo != null && !Nombre.Equals("") && !Codigo.Equals(""))
            {
                Producto nuevoProd = new Producto(Nombre, Codigo);
                var response = await App.Database.AddProductoAsync(nuevoProd);
                await NavigationService.GoBackAsync();
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync(AppResources.EtiquetaError, AppResources.ErrorAgregarProducto, AppResources.EtiquetaOk);
            }
        }
        #endregion
    }
}

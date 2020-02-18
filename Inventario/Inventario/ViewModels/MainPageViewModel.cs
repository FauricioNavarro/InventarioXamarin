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
    public class MainPageViewModel : ViewModelBase
    {
        #region Parámetros
        private DelegateCommand _getProductos;
        public DelegateCommand GetProductos
        {
            get { return _getProductos; }
            set { SetProperty(ref _getProductos, value); }
        }

        private DelegateCommand _getCompras;
        public DelegateCommand GetCompras
        {
            get { return _getCompras; }
            set { SetProperty(ref _getCompras, value); }
        }

        private DelegateCommand _getFacturas;
        public DelegateCommand GetFacturas
        {
            get { return _getFacturas; }
            set { SetProperty(ref _getFacturas, value); }
        }
        #endregion

        #region Constructor
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Inventario";
            GetProductos = new DelegateCommand(EjecutarGetProductos);
            GetCompras = new DelegateCommand(EjecutarGetCompras);
            GetFacturas = new DelegateCommand(EjecutarGetFacturas);
        }
        #endregion

        #region Métodos
        protected async void EjecutarGetProductos()
        {
            await NavigationService.NavigateAsync("Productos");
        }

        protected async void EjecutarGetCompras()
        {
            await NavigationService.NavigateAsync("Compras");
        }

        protected async void EjecutarGetFacturas()
        {
            await NavigationService.NavigateAsync("Facturas");
        }
        #endregion        
    }
}

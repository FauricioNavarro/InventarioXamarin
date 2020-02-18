using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario.Models;

namespace Inventario.ViewModels
{
	public class DetalleProductoViewModel : ViewModelBase
	{

        private Producto _producto = new Producto();
        public Producto Producto
        {
            get { return _producto; }
            set { SetProperty(ref _producto, value); }
        }

        private DelegateCommand _comprarProducto;
        public DelegateCommand ComprarProducto
        {
            get { return _comprarProducto; }
            set { SetProperty(ref _comprarProducto, value); }
        }

        private DelegateCommand _facturarProducto;
        public DelegateCommand FacturarProducto
        {
            get { return _facturarProducto; }
            set { SetProperty(ref _facturarProducto, value); }
        }


        public DetalleProductoViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            ComprarProducto = new DelegateCommand(EjecutarComprarProducto);
            FacturarProducto = new DelegateCommand(EjecutarFacturarProducto);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var parametroTemp = (Producto)parameters["productoSeleccionado"];
            if (parametroTemp != null)
            {
                Producto = parametroTemp;
            }
            else
            {
                findProducto();
            }
        }

        //public async override void OnNavigatedFrom(INavigationParameters parameters)
        //{
        //    //Producto = await App.Database.FindProductoAsync(Producto.Id);
        //    Console.WriteLine("From");
        //}

        protected async void findProducto()
        {
            Producto = await App.Database.FindProductoAsync(Producto.Id);
        }

        protected async void EjecutarComprarProducto()
        {
            var parametro = new NavigationParameters();
            parametro.Add("productoSeleccionado", Producto);
            await NavigationService.NavigateAsync("CompraProducto", parametro);
        }

        protected async void EjecutarFacturarProducto()
        {
            var parametro = new NavigationParameters();
            parametro.Add("productoSeleccionado", Producto);
            await NavigationService.NavigateAsync("FacturaProducto", parametro);
        }
    }
}

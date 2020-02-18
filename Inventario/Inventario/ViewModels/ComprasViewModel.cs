using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Inventario.Models;

namespace Inventario.ViewModels
{
	public class ComprasViewModel : ViewModelBase
	{
        private List<Compra> _ListaCompras;
        public List<Compra> ListaCompras
        {
            get { return _ListaCompras; }
            set { SetProperty(ref _ListaCompras, value); }
        }

        public ComprasViewModel(INavigationService navigationService)
            :base(navigationService)
        {
            getCompras();
        }

        protected async void getCompras()
        {
            ListaCompras = await App.Database.GetComprasAsync();
            Console.WriteLine(ListaCompras);
        }
	}
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Inventario.Models;

namespace Inventario.ViewModels
{
	public class FacturasViewModel : ViewModelBase
	{
        private List<Factura> _listaFacturas;
        public List<Factura> ListaFacturas
        {
            get { return _listaFacturas; }
            set { SetProperty(ref _listaFacturas, value); }
        }

        public FacturasViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            getFacturas();
        }

        protected async void getFacturas()
        {
            ListaFacturas = await App.Database.GetFacturasAsync();
        }
    }
}

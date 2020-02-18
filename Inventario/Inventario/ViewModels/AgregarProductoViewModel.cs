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

        public DelegateCommand agregarProducto { get; private set; }
        #endregion

        #region Constructor
        public AgregarProductoViewModel(INavigationService navigationService,IPageDialogService pageDialogService)
            : base(navigationService)
        {
            _pageDialogService = pageDialogService;
            agregarProducto = new DelegateCommand(AgregarProducto);
            agregarProducto.ObservesProperty(()=> Nombre);
            agregarProducto.ObservesProperty(()=> Codigo);
        }
        #endregion

        #region Métodos
        public async void AgregarProducto()
        {
            if(Nombre != null && Codigo != null && !Nombre.Equals("") && !Codigo.Equals(""))
            {
                Producto nuevoProd = new Producto(Nombre, Codigo);
                var response = await App.Database.AddProductoAsync(nuevoProd);
                await NavigationService.GoBackAsync();
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync(Mensajes.tituloError, Mensajes.errorAgregarProducto, Mensajes.respuestaOk);
            }

        }
        #endregion
    }
}

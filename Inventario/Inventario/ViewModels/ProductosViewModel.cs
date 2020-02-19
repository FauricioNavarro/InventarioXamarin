using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario.Models;
using Inventario.Resx;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Services;

namespace Inventario.ViewModels
{
	public class ProductosViewModel : ViewModelBase
    {
        #region Parámetros        
        private IPageDialogService _pageDialogService { get; set; }

        private Producto _productoSeleccionado { get; set; }
        public Producto ProductoSeleccionado
        {
            get { return _productoSeleccionado; }
            set
            {
                if (_productoSeleccionado != value)
                {
                    _productoSeleccionado = value;
                    VerProductoSelecctionado();
                }
            }
        }

        private List<Producto> _listaProducto;
        public List<Producto> ListaProducto
        {
            get { return _listaProducto; }
            set { SetProperty(ref _listaProducto, value); }
        }

        private DelegateCommand _agregarProducto;
        public DelegateCommand AgregarProducto =>
            _agregarProducto ?? (_agregarProducto = new DelegateCommand(accionAgregarProducto));

        public ICommand EliminaProducto
        {
            get
            {
                return new Command((e) =>
                {
                    var item = (e as Producto);
                    EliminarProductoSelecctionado(item);
                });
            }
        }

        public ICommand EditarProducto
        {
            get
            {
                return new Command((e) =>
                {
                    var item = (e as Producto);
                    EditarProductoSelecctionado(item);
                });
            }
        }
        #endregion

        #region Constructor
        public ProductosViewModel(INavigationService navigationService,IPageDialogService pageDialogService)
            : base(navigationService)
        {
            Title = "Productos";
            _pageDialogService = pageDialogService;
            GetProducto();
        }
        #endregion

        #region Métodos        
        public async void accionAgregarProducto()
        {
            await NavigationService.NavigateAsync("AgregarProducto");
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            GetProducto();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            GetProducto();
        }

        protected async void VerProductoSelecctionado()
        {
            var parameters = new NavigationParameters();
            parameters.Add("productoSeleccionado", ProductoSeleccionado);

            await NavigationService.NavigateAsync("DetalleProducto", parameters);
        }

        protected async void GetProducto()
        {
            ListaProducto = await App.Database.GetProductosAsync();
        }

        protected async void EliminarProductoSelecctionado(Producto producto)
        {
            var result = await _pageDialogService.DisplayAlertAsync(AppResources.TituloEliminarProducto, AppResources.TextoEliminarProducto, AppResources.EtiquetaSi, AppResources.EtiquetaNo);
            if (result)
            {
                await App.Database.DeleteProductoAsync(producto);
                GetProducto();
            }
        }
        protected async void EditarProductoSelecctionado(Producto producto)
        {
            var parametros = new NavigationParameters();
            parametros.Add("productoSeleccionado", producto);

            await NavigationService.NavigateAsync("EditarProducto", parametros);
            
        }
        #endregion
    }
}

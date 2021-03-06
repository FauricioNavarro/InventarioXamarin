﻿using System;
using System.IO;
using Prism;
using Prism.Ioc;
using Inventario.ViewModels;
using Inventario.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Inventario.Datos;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Inventario
{
    public partial class App
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    string path = Path.Combine(folder, "Inventario.db3");
                    database = new Database(path);
                }
                return database;
            }
        }
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            //

            await NavigationService.NavigateAsync("Menu");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {            
            containerRegistry.RegisterForNavigation<Views.Menu, MenuViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<Productos, ProductosViewModel>();
            containerRegistry.RegisterForNavigation<AgregarProducto, AgregarProductoViewModel>();
            containerRegistry.RegisterForNavigation<DetalleProducto, DetalleProductoViewModel>();
            containerRegistry.RegisterForNavigation<CompraProducto, CompraProductoViewModel>();
            containerRegistry.RegisterForNavigation<Compras, ComprasViewModel>();
            containerRegistry.RegisterForNavigation<FacturaProducto, FacturaProductoViewModel>();
            containerRegistry.RegisterForNavigation<Facturas, FacturasViewModel>();
            containerRegistry.RegisterForNavigation<EditarProducto, EditarProductoViewModel>();
        }
    }
}

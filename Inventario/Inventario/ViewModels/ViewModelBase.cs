using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, IDestructible, INavigationAware
    {        
        protected INavigationService NavigationService { get; private set; }  

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        //public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService)
        //{
        //    NavigationService = navigationService;
        //    PageDialogService = pageDialogService;
        //}

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}

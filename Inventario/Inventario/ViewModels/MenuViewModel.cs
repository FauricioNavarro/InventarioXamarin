using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventario.ViewModels
{
	public class MenuViewModel : ViewModelBase
	{
        private DelegateCommand<string> _navigateCommand;
        public DelegateCommand<string> NavigateCommand
        {
            get { return _navigateCommand; }
            set { SetProperty(ref _navigateCommand, value); }
        }

        public MenuViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            NavigateCommand = new DelegateCommand<string>(ExecNavigateCommand);
        }

        protected async void ExecNavigateCommand(string page)
        {
            await NavigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }
    }
}

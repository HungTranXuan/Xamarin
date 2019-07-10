using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ManuallyPrism.Views;
using System.Threading.Tasks;
using Prism.Services;

namespace ManuallyPrism.ViewModels
{
    public class PrismNavigationPageViewModel : ViewModelBase, IConfirmNavigationAsync
    {
        private DelegateCommand _navigateCommand;
        private DelegateCommand _speechCommand;
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private readonly ITextToSpeech _speechService;

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteDelegateCommand));

        public DelegateCommand SpeechCommand =>
            _speechCommand ?? (_speechCommand = new DelegateCommand(ExecuteSpeechCommand));

        private string entryTextField;
        public string EntryTextField
        {
            get => entryTextField;
            set => SetProperty(ref entryTextField, value);
        }

        public PrismNavigationPageViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService, ITextToSpeech speechService) : base(navigationService)
        {
            Title = "Test Prism Navigation on Master Detail Page on Xamarin Form 8.0 and Prism 7.1";
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _speechService = speechService;
        }

        async void ExecuteDelegateCommand()
        {
            var param = new NavigationParameters();
            param.Add("title", EntryTextField);

            await _navigationService.NavigateAsync("ViewA", param);
        }

        void ExecuteSpeechCommand()
        {
            _speechService.Speak(EntryTextField);
        }

        public Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return _pageDialogService.DisplayAlertAsync("Warning", "Do you want to allow this page to navigate to View A?", "Yes", "No");
        }
    }
}

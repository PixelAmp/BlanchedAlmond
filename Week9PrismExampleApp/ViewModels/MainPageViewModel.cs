using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Microsoft.AppCenter.Analytics;
using PUBGSharp.Data;

[assembly: InternalsVisibleTo("Week9PrismExampleUnitTests")]
namespace Week9PrismExampleApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand NavToNewPageCommand { get; set; }
        public DelegateCommand NavToTimerPageCommand { get; set; }
        public DelegateCommand NavToUserStatsPageCommand { get; set; }

        private INavigationService _navigationService;
        private IPageDialogService _dialogService;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            NavToNewPageCommand = new DelegateCommand(NavToNewPage);
            NavToTimerPageCommand = new DelegateCommand(NavToTimerPage);
            NavToUserStatsPageCommand = new DelegateCommand(NavToUserStatsPage);
        }

        private bool _IsLoading;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set { SetProperty(ref _IsLoading, value); }
        }


        private async void NavToNewPage()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NavFromPage", "MainPageViewModel");
            await _navigationService.NavigateAsync("SearchUserPage", navParams);
        }

        private async void NavToTimerPage()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NavFromPage", "MainPageViewModel");
            await _navigationService.NavigateAsync("TimerPage", navParams);
        }

        private async void NavToUserStatsPage()
        {
            IsLoading = true;
            try
            {
                PUBGSharp.PUBGStatsClient statsClient = new PUBGSharp.PUBGStatsClient(ApiKeys.PUBG);
                var stats = await statsClient.GetPlayerStatsAsync("cookiedragon4", Region.NA);
                IsLoading = false;
                var navParams = new NavigationParameters();
                navParams.Add("NavFromPage", "MainPageViewModel");
                navParams.Add("Stats", stats);
                await _navigationService.NavigateAsync("UserStatsPage", navParams);
            }
            catch (Exception ex)
            {
                IsLoading = false;
                await _dialogService.DisplayAlertAsync("Error", ex.Message, "OK");
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}


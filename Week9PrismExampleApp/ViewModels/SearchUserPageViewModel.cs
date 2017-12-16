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

using Xamarin.Forms;
using System.Text;
using Newtonsoft.Json;
using PUBGSharp.Data;

namespace Week9PrismExampleApp.ViewModels
{
    public class SearchUserPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;
        private IPageDialogService _dialogService;
        public DelegateCommand SearchButtonClickedCommand { get; set; }
        public DelegateCommand BackNavCommand { get; set; }
        private PUBGSharp.PUBGStatsClient statsClient;

        public SearchUserPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            SearchButtonClickedCommand = new DelegateCommand(SearchButtonClicked);
            BackNavCommand = new DelegateCommand(BackNav);
            statsClient = new PUBGSharp.PUBGStatsClient(ApiKeys.PUBG);
        }

        private string _TestLabelText;
        public string TestLabelText
        {
            get { return _TestLabelText; }
            set { SetProperty(ref _TestLabelText, value); }
        }

        private bool _IsLoading;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set { SetProperty(ref _IsLoading, value); }
        }

        private string _SearchUser_Entry_Text;
        public string SearchUser_Entry_Text
        {
            get { return _SearchUser_Entry_Text; }
            set { SetProperty(ref _SearchUser_Entry_Text, value); }
        }

        public async void SearchButtonClicked()
        {
            if (SearchUser_Entry_Text == null || SearchUser_Entry_Text == "")
            {
                await _dialogService.DisplayAlertAsync("Error", "Please enter a username", "OK");
                return;
            }
            IsLoading = true;
            try
            {
                var stats = await statsClient.GetPlayerStatsAsync(SearchUser_Entry_Text, Region.NA);
                IsLoading = false;
                var navParams = new NavigationParameters();
                navParams.Add("Stats", stats);
                navParams.Add("NavFromPage", "SearchUserPageViewModel");
                await _navigationService.NavigateAsync("UserStatsPage", navParams);

            }
            catch (Exception ex)
            {
                IsLoading = false;
                await _dialogService.DisplayAlertAsync("Error", ex.Message, "OK");
            }
        }

        public async void BackNav()
        {
            await _navigationService.GoBackAsync();
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

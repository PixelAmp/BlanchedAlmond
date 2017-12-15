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
        private PUBGSharp.PUBGStatsClient statsClient;

        public HttpResponseMessage responseMessage = new HttpResponseMessage();

        public SearchUserPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            SearchButtonClickedCommand = new DelegateCommand(SearchButtonClicked);
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
            //TestLabelText = "Retrieving...";
            IsLoading = true;
            try
            {
                var stats = await statsClient.GetPlayerStatsAsync(SearchUser_Entry_Text ?? "cookiedragon4", Region.NA);
                //TestLabelText = JsonConvert.SerializeObject(stats.Stats).Substring(0, 10000); //cannot be too long or it wont show
                IsLoading = false;
                var navParams = new NavigationParameters();
                navParams.Add("Stats", stats);
                await _navigationService.NavigateAsync("UserStatsPage", navParams);

            } catch (Exception ex)
            {
                IsLoading = false;
                await _dialogService.DisplayAlertAsync("Error", ex.ToString(), "OK");
                //TestLabelText = "";
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

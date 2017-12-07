﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Navigation;
using PUBGSharp;
using PUBGSharp.Data;
using PUBGSharp.Net.Model;

namespace Week9PrismExampleApp.ViewModels
{
    public class UserStatsPageViewModel : BindableBase, INavigationAware
    {

        private StatsResponse _statsResponse;
        public StatsResponse StatsResponse
        {
            get { return _statsResponse; }
            set { SetProperty(ref _statsResponse, value); }
        }

        public UserStatsPageViewModel()
        {
            //StatsResponse = LoadUserStats("cookiedragon4").Result;
        }

        public async Task<StatsResponse> LoadUserStats(string username)
        {
            var pubgService = new PUBGStatsClient(ApiKeys.PUBG);
            var stats = await pubgService.GetPlayerStatsAsync(username, Region.NA, Mode.All);
            return stats;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            StatsResponse = (StatsResponse)parameters["stats"];
        }
    }
}

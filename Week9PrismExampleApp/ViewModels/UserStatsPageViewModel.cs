using Prism.Commands;
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
            
        }

        public async Task<StatsResponse> LoadUserStats(string username)
        {
            var pubgService = new PUBGStatsClient(ApiKeys.PUBG);
            var stats = await pubgService.GetPlayerStatsAsync(username, Region.NA, Mode.All);

            //stats.Stats[0].Stats[0].Stat
            return stats;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            StatsResponse = (StatsResponse)parameters["Stats"];
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            StatsResponse = (StatsResponse)parameters["Stats"];
        }
         
    }
}

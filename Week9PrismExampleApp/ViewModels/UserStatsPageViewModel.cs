using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PUBGSharp;
using PUBGSharp.Data;
using PUBGSharp.Net.Model;

namespace Week9PrismExampleApp.ViewModels
{
    public class UserStatsPageViewModel : BindableBase
    {
        public UserStatsPageViewModel()
        {
            
        }

        public async Task<StatsResponse> LoadUserStats(string username)
        {
            var pubgService = new PUBGStatsClient(ApiKeys.WeatherKey);
            var stats = await pubgService.GetPlayerStatsAsync(username, Region.NA, Mode.All);
            return stats;
        }
    }
}

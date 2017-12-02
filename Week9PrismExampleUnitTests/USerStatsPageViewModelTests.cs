using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Week9PrismExampleApp.ViewModels;
using Prism.Navigation;
using Moq;
using static Week9PrismExampleApp.Models.WeatherItemModel;

namespace Week9PrismExampleUnitTests
{
    [TestFixture]
    public class UserStatsPageViewModelTests
    {
        UserStatsPageViewModel userStatsPageViewModel;

        [SetUp]
        public void Init()
        {
            userStatsPageViewModel = new UserStatsPageViewModel();
        }

        [Test]
        public async Task TestApi()
        {
            var result = await userStatsPageViewModel.LoadUserStats("CookieDragon4");
        }

    }
}

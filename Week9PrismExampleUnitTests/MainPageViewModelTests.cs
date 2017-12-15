using NUnit.Framework;
using System;
using Week9PrismExampleApp.ViewModels;
using Prism.Navigation;
using Moq;
using Prism.Services;

namespace Week9PrismExampleUnitTests
{
    [TestFixture]
    public class MainPageViewModelTests
    {
        MainPageViewModel mainPageViewModel;

        Mock<INavigationService> navigationServiceMock;
        Mock<IPageDialogService> dialogServiceMock;
        [SetUp]
        public void Init()
        {
            navigationServiceMock = new Mock<INavigationService>();
            dialogServiceMock = new Mock<IPageDialogService>();
            mainPageViewModel = new MainPageViewModel(navigationServiceMock.Object, dialogServiceMock.Object);
        }

        [Test]
        public void TestNavToNewPageCommandNavigateAsyncWithCorrectParameters()
        {
            // Arrange: create expected NavParameters, do Mock setup for navigation
            var expectedNavParams = new NavigationParameters();
            expectedNavParams.Add("NavFromPage", "MainPageViewModel");
            navigationServiceMock.Setup(
                ns => ns.NavigateAsync(It.IsAny<string>(),
                                     It.IsAny<NavigationParameters>(),
                                     It.IsAny<bool?>(),
                                       It.IsAny<bool>()));

            // Act: Call the method/command under test
            mainPageViewModel.NavToNewPageCommand.Execute();

            // Assert: Verify that proper navigate async call was made once
            navigationServiceMock.Verify(
                ns => ns.NavigateAsync("SamplePageForNavigation",
                                     expectedNavParams,
                                    false,
                                     true), Times.Once());
        }


        [Test]
        public void TestNavToTimerPageCommandNavigateAsyncWithCorrectParameters()
        {
            // Arrange: create expected NavParameters, do Mock setup for navigation
            var expectedNavParams = new NavigationParameters();
            expectedNavParams.Add("NavFromPage", "TimerPageViewModel");
            navigationServiceMock.Setup(
                ns => ns.NavigateAsync(It.IsAny<string>(),
                                     It.IsAny<NavigationParameters>(),
                                     It.IsAny<bool?>(),
                                       It.IsAny<bool>()));

            // Act: Call the method/command under test
            mainPageViewModel.NavToTimerPageCommand.Execute();

            // Assert: Verify that proper navigate async call was made once
            navigationServiceMock.Verify(
                ns => ns.NavigateAsync("SamplePageForNavigation",
                                     expectedNavParams,
                                    false,
                                     true), Times.Once());
        }

        [Test]
		public void TestNavToMoreInfoPageCommandNavigateAsyncWithCorrectParameters()
		{
		}
    }
}

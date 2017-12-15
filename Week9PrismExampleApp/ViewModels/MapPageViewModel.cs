using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.AppCenter.Analytics;
using System.Threading;
using Xamarin.Forms;
using System.Text;


namespace Week9PrismExampleApp.ViewModels
{
    public class MapPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;
        public DelegateCommand LocButtonClickedCommand { get; set; }
        string[] Urls = { "/images/everny.png","/images/georgopel.png","/images/lipovka.png","/images/military.png","/images/mylta.png","/images/pochinki.png","/images/rozhok.png","/images/yasnaya.png" };
        string[] UrlNames = { "Everny", "Georgopool", "Lipovka", "Military", "Mylta", "Pochinki", "Rozhok", "Yasnaya" };

        private string _LocName;
        public string LocName
        {
            get { return _LocName; }
            set { SetProperty(ref _LocName, value); }
        }

        private string _DisplayLocation;
        public string DisplayLocation
        {
            get { return _DisplayLocation; }
            set { SetProperty(ref _DisplayLocation, value); }
        }

        private string _ImgHeight;
        public string ImgHeight
        {
            get { return _ImgHeight; }
            set { SetProperty(ref _ImgHeight,value);}
        }

        private string _ImgWidth;
        public string ImgWidth
        {
            get { return _ImgWidth; }
            set { SetProperty(ref _ImgWidth, value); }
        }

        public MapPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            var embededImage = new Image { Aspect = Aspect.AspectFit };
            LocButtonClickedCommand = new DelegateCommand(LocButtonClicked);
        }

        public int GetRandom()
        {
            int R;
            Random RNG = new Random();
            R = RNG.Next(0, Urls.Length - 1 );
            return R;
        }

        void LocButtonClicked()
        {
            int R = GetRandom();
            ImgWidth = "40";
            ImgHeight = "40";
            DisplayLocation = "/Users/Matt/BlanchedAlmond/Week9PrismExampleApp" + Urls[R];
            LocName = UrlNames[R];
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

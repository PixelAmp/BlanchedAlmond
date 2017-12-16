using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Microsoft.AppCenter.Analytics;
using System.Threading;
using Xamarin.Forms;
using System.Threading.Tasks;

//https://www.reddit.com/r/PUBATTLEGROUNDS/comments/6odhok/circle_breakdown_times_damage_travel_time_and_tips/
//a bit outdated I think, but a good starting point

[assembly: InternalsVisibleTo("Week9PrismExampleUnitTests")] //testing
namespace Week9PrismExampleApp.ViewModels
{
    public class TimerPageViewModel : BindableBase
    {
        private INavigationService _navigationService;

        int shrink = 0;
        int second = 0;
        int minute = 5;
        bool timer = false;

        public DelegateCommand ResetTimerCommand { get; set; }
        public DelegateCommand StartTimerCommand { get; set; }
        public DelegateCommand GoToMapCommand { get; set; }

        public TimerPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoToMapCommand = new DelegateCommand(GoToMap);
            ResetTimerCommand = new DelegateCommand(ResetTimer);
            StartTimerCommand = new DelegateCommand(StartTimer);
        }


        private string _secNum;
        public string SecNum
        {
            get { return _secNum; }
            set { SetProperty(ref _secNum, value); }
        }

        private string _minNum;
        public string MinNum
        {
            get { return _minNum; }
            set { SetProperty(ref _minNum, value); }
        }

        private string _circeNum;
        public string CirceNum
        {
            get { return _circeNum; }
            set { SetProperty(ref _circeNum, value); }
        }

        private string _lengthNum;
        public string LengthNum
        {
            get { return _lengthNum; }
            set { SetProperty(ref _lengthNum, value); }
        }

        private string _damageNum;
        public string DamageNum
        {
            get { return _damageNum; }
            set { SetProperty(ref _damageNum, value); }
        }

        void ResetTimer()
        {
            timer = false;
            second = 0;
            minute = 5;
            shrink = 0;
            MinNum = minute.ToString();
            if (second < 10)
                SecNum = "0" + second.ToString();

            else
                SecNum = second.ToString();

            CirceNum = "1";
            LengthNum = "4550m";
            DamageNum = "0.4%";
        }

        void StartTimer()
        {
            if (timer == false)
            {
                ResetTimer();
                timer = true;
                TimerLoop();
            }
        }

        public async void GoToMap()
        {
            await _navigationService.NavigateAsync("MapPage");
        }

        public void OnStart()
        {
            ResetTimer();

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            ResetTimer();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            ResetTimer();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            ResetTimer();

        }

        void UpdatePage()
        {
            switch (shrink)
            {
                case 1: //circle shrinking for first time
                    second = 0;
                    minute = 5;
                    CirceNum = "1";
                    LengthNum = "4550m";
                    DamageNum = "0.4%";
                    break;
                case 3: //second cicle shrink
                    second = 20;
                    minute = 2;
                    CirceNum = "2";
                    LengthNum = "2970m";
                    DamageNum = "0.6%";
                    break;
                case 5: //third circle
                    second = 30;
                    minute = 1;
                    CirceNum = "3";
                    LengthNum = "1480m";
                    DamageNum = "0.8%";
                    break;
                case 7: //fourth circle
                    second = 0;
                    minute = 1;
                    CirceNum = "4";
                    LengthNum = "740m";
                    DamageNum = "1.0%";
                    break;
                case 9: //fifth cicle
                    second = 40;
                    minute = 0;
                    CirceNum = "5";
                    LengthNum = "360m";
                    DamageNum = "3.0%";
                    break;
                case 11: //sixth cicle
                    second = 30;
                    minute = 0;
                    CirceNum = "6";
                    LengthNum = "175m";
                    DamageNum = "5.0%";
                    break;
                case 13: //seventh cicle
                    second = 30;
                    minute = 0;
                    CirceNum = "7";
                    LengthNum = "90m";
                    DamageNum = "7.0%";
                    break;
                case 15: //last cicle
                    second = 10;
                    minute = 0;
                    CirceNum = "8";
                    LengthNum = "40m";
                    DamageNum = "11.0%";
                    timer = false;
                    break;

                case 2: //first cool down after first circle
                    second = 20;
                    minute = 3;
                    break;
                case 4: //second cool down after second circle
                    second = 20;
                    minute = 3;
                    break;
                case 6: //second cool down after third circle
                    second = 0;
                    minute = 2;
                    break;
                case 8: //second cool down after fourth circle
                    second = 30;
                    minute = 1;
                    break;
                case 10: //second cool down after fifth circle
                    second = 0;
                    minute = 1;
                    break;
                case 12: //second cool down after fifth circle
                    second = 15;
                    minute = 0;
                    break;

                default:
                    second = 0;
                    minute = 0;
                    CirceNum = "1";
                    LengthNum = "4550m";
                    DamageNum = "0.4%";
                    timer = false;
                    break;
            }
        }

        void TimerLoop()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (timer)
                {
                    TimeKeep();
                    return true; //continue
                }
                return false; //not continue
            });
        }

        void TimeKeep()
        {
            second--;
            if (second < 0)
            {
                minute--;
                second = 59;
            }

            if (minute == 0 && second == 0)
            {
                shrink++;
                UpdatePage();

            }

            MinNum = minute.ToString();
            if (second < 10)
            {
                SecNum = "0" + second.ToString();
            }
            else
            {
                SecNum = second.ToString();
            }
        }
    }    
}

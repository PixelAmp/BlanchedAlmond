using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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

//https://www.reddit.com/r/PUBATTLEGROUNDS/comments/6odhok/circle_breakdown_times_damage_travel_time_and_tips/
//a bit outdated I think, but a good starting point

[assembly: InternalsVisibleTo("Week9PrismExampleUnitTests")] //testing
namespace Week9PrismExampleApp.ViewModels
{
    public class TimerPageViewModel : BindableBase
    {
        public DelegateCommand ResetTimerCommand { get; set; }
        public DelegateCommand StartTimerCommand { get; set; }
        public DelegateCommand ShowInfoCommand { get; set; }


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


        int CircleLayer;

        public TimerPageViewModel()
        {
            ResetTimerCommand = new DelegateCommand(ResetTimer);
            StartTimerCommand = new DelegateCommand(StartTimer);
            ShowInfoCommand = new DelegateCommand(ShowInfo);
        }

        void ResetTimer()
        {
            CircleLayer = 1;
            CirceNum = "1";
            LengthNum = "4550";
            DamageNum = "0.4%";
        }

        void StartTimer()
        {
            //CircleLayer++;
            UpdatePage();
            timerthing();
        }

        void ShowInfo()
        {

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
            switch (CircleLayer)
            {
                case 1:
                    CirceNum = "1";
                    LengthNum = "4550m";
                    DamageNum = "0.4%";
                    break;
                case 2:
                    CirceNum = "2";
                    LengthNum = "2970m";
                    DamageNum = "0.6%";
                    break;
                case 3:
                    CirceNum = "3";
                    LengthNum = "1480m";
                    DamageNum = "0.8%";
                    break;
                case 4:
                    CirceNum = "4";
                    LengthNum = "740m";
                    DamageNum = "1.0%";
                    break;
                case 5:
                    CirceNum = "5";
                    LengthNum = "360m";
                    DamageNum = "3.0%";
                    break;
                case 6:
                    CirceNum = "6";
                    LengthNum = "175m";
                    DamageNum = "5.0%";
                    break;
                case 7:
                    CirceNum = "7";
                    LengthNum = "90m";
                    DamageNum = "7.0%";
                    break;
                case 8:
                    CirceNum = "8";
                    LengthNum = "40m";
                    DamageNum = "11.0%";
                    break;
                default:
                    CircleLayer = 1;
                    CirceNum = "1";
                    LengthNum = "4550m";
                    DamageNum = "0.4%";
                    break;

            }
        }

        

        void timerthing()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                CircleLayer++;
                UpdatePage();
                if (CircleLayer <= 60)
                {
                    return true; //continue
                }
                return false; //not continue

            });
        }

    }
    
}

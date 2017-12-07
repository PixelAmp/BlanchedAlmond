using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Microsoft.AppCenter.Analytics;
using System.Threading;

[assembly: InternalsVisibleTo("Week9PrismExampleUnitTests")] //testing
namespace Week9PrismExampleApp.ViewModels
{
    public class TimerPageViewModel : BindableBase
    {
        public DelegateCommand ResetTimerCommand { get; set; }
        public DelegateCommand StartTimerCommand { get; set; }

        public TimerPageViewModel()
        {
            ResetTimerCommand = new DelegateCommand(ResetTimer);
            StartTimerCommand = new DelegateCommand(StartTimer);
        }

        void ResetTimer()
        {
            
        }

        void StartTimer()
        {

        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

    }
}

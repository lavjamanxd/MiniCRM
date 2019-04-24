using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using MiniCRM.Core;

namespace MiniCRM.UWP
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> _navigationMap = new Dictionary<Type, Type>
        {
            {typeof(LoginViewModel), typeof(MainPage)},
            {typeof(CalendarViewModel), typeof(CalendarPage)},
            {typeof(CreateFormViewModel), typeof(CreateForm)}
        };

        private readonly Frame _currentFrame;

        public NavigationService(Frame currentFrame)
        {
            _currentFrame = currentFrame;
        }

        public void Navigate(ViewModel page)
        {
            _currentFrame.Navigate(_navigationMap[page.GetType()], page);
        }
    }
}
using System.Windows.Input;

namespace MiniCRM.Core
{
    public class LoginViewModel
    {
        private readonly INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand LoginToCalendarCommand => new Command<string>(LoginToCalendar);

        private void LoginToCalendar(string userId)
        {
            _navigationService.Navigate(new CalendarViewModel(userId));
        }
    }
}
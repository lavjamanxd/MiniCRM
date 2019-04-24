using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MiniCRM.Core.ServerAccess;
using MiniCRM.Shared;

namespace MiniCRM.Core
{
    public class CalendarViewModel : ViewModel
    {
        private readonly int _userId;

        public string DateToDisplay => Date.ToShortDateString();

        private DateTime _date;
        private readonly MiniCrmBackend _backend;

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(DateToDisplay));
                GetNewAppointments();
            }
        }

        private async Task GetNewAppointments()
        {
            Items = await _backend.GetAppointments(_userId, Date.Date, Date.AddDays(1).Date);
        }

        private IEnumerable<Appointment> _items;

        public IEnumerable<Appointment> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public ICommand MoveToNextDayCommand => new Command<string>(ToNextDay);
        public ICommand MoveToPreviousDayCommand => new Command<string>(ToPreviousDay);

        public CalendarViewModel(string userId)
        {
            _userId = int.Parse(userId);
            _backend = new MiniCrmBackend();
            Date = DateTime.Today;
        }

        private void ToPreviousDay(string obj) => Date = Date.AddDays(-1);
        private void ToNextDay(string obj) => Date = Date.AddDays(1);
    }
}
using System;
using System.Collections.Generic;

namespace MeetingManagement.Navigation
{
    public class MeetingsScreen : Screen
    {
        private DateTime dateTime;
        private IMeetingService _meetingService;
        private ITimetableExportService _timetableExportService;

        public MeetingsScreen(DateTime date) : base()
        {
            dateTime = date;
            var repository = MeetingRepository.GetInstance();
            _meetingService = new MeetingService(repository);
            _timetableExportService = new TimetableExportService();
        }
        
        public override void Show()
        {
            var meetings = _meetingService.GetTimetable(dateTime);
            if (meetings.Count == 0)
            {
                navigation.NavigateTo(new ResultScreen("Встреч нет"));
                return;
            }

            var meetingNumber = 1;
            foreach (var meeting in meetings)
            {
                Console.WriteLine($"[{meetingNumber}]: {meeting.Description}");
                Console.WriteLine("Начало в " 
                    + $"{DatetimeProvider.ConvertToShortTimeString(meeting.StartTime)}");
                Console.WriteLine("Конец в " 
                    + $"{DatetimeProvider.ConvertToShortTimeString(meeting.EndTime)}");
                Console.WriteLine("Напомнить в " 
                    + $"{DatetimeProvider.ConvertToShortTimeString(meeting.NotificationTime)}");
                Console.WriteLine();
                meetingNumber++;
            }

            ShowMenuItems(meetings);
        }

        private void ShowMenuItems(IEnumerable<Meeting> meetings)
        {
            const string selectMeetingMenuItem = "1. Выбрать встречу";
            Console.WriteLine(selectMeetingMenuItem);
            const string exportFileMenuItem = "2. Экспортировать";
            Console.WriteLine(exportFileMenuItem);
            var selectedMenuItem = Console.ReadLine();

            switch (selectedMenuItem)
            {
                case "1":
                    var chooseMeetingScreen = new ChooseMeetingScreen(meetings);
                    navigation.NavigateTo(chooseMeetingScreen);
                    break;
                case "2":
                    var fileName = $"Расписание на {dateTime.ToShortDateString()}";
                    _timetableExportService.ExportFile(meetings, fileName);
                    navigation.NavigateTo(new ResultScreen("Успешно экспортировано"));
                    break;
            }
        }
    }
}

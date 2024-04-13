using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingManagement.Navigation
{
    public class ChooseMeetingScreen : Screen
    {
        private IEnumerable<Meeting> _meetings;

        public ChooseMeetingScreen(IEnumerable<Meeting> meetings) : base()
        {
            _meetings = meetings;
        }

        public override void Show()
        {
            var meetingNumber = 1;
            foreach (var meeting in _meetings)
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

            const string readMeetingNumberMenuItem = "Введите номер встречи: ";
            Console.Write(readMeetingNumberMenuItem);
            var selectedNumber = int.Parse(Console.ReadLine());
            var selectedMeeting = _meetings.ElementAt(selectedNumber - 1);

            navigation.NavigateTo(new MeetingScreen(selectedMeeting.Id));
        }
    }
}

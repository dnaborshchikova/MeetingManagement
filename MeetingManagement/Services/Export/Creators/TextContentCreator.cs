using System.Collections.Generic;
using System.Text;

namespace MeetingManagement
{
    public class TextContentCreator : IContentCreator
    {
        public string Generate(IEnumerable<Meeting> meetings)
        {
            var meetingText = new StringBuilder();
            var meetingNumber = 1;

            foreach (var meeting in meetings)
            {
                meetingText.AppendLine($"Встреча №{meetingNumber}:");
                meetingText.AppendLine(meeting.Description);

                var startTime
                    = $"Начало в {DatetimeProvider.ConvertToShortTimeString(meeting.StartTime)}";
                meetingText.AppendLine(startTime);

                var endTime 
                    = $"Окончание в {DatetimeProvider.ConvertToShortTimeString(meeting.EndTime)}";
                meetingText.AppendLine(endTime);

                var notificationTime = "Напомнить в " 
                    + $"{DatetimeProvider.ConvertToShortTimeString(meeting.NotificationTime)}";
                meetingText.AppendLine(notificationTime);

                meetingNumber++;
            } 

            return meetingText.ToString();
        }
    }
}

using System;

namespace MeetingManagement.Navigation
{
    public class AddMeetingScreen : Screen
    {
        private IMeetingService _meetingService;

        public AddMeetingScreen() : base()
        {
            var repository = MeetingRepository.GetInstance();
            _meetingService = new MeetingService(repository);
        }

        public override void Show()
        {
            Console.Write("Введите описание: ");
            var meetingDescription = Console.ReadLine();
            Console.WriteLine($"Дата начала ({DatetimeConfig.DatetimeFormat})");
            var startTime = Console.ReadLine();
            Console.WriteLine($"Дата окончания ({DatetimeConfig.DatetimeFormat})");
            var endTime = Console.ReadLine();
            Console.WriteLine($"Время напоминания ({DatetimeConfig.DatetimeFormat})");
            var notificationTime = Console.ReadLine();

            var formattedStartTime = DateTime.ParseExact(startTime, DatetimeConfig.DatetimeFormat
                , System.Globalization.CultureInfo.InvariantCulture);
            var formattedEndTime = DateTime.ParseExact(endTime, DatetimeConfig.DatetimeFormat
                , System.Globalization.CultureInfo.InvariantCulture);
            var formattedNotificationTime = DateTime.ParseExact(notificationTime
                , DatetimeConfig.DatetimeFormat, System.Globalization.CultureInfo.InvariantCulture);

            try
            {
                _meetingService.AddMeeting(meetingDescription, formattedStartTime
                    , formattedEndTime, formattedNotificationTime);
                const string addMeetingMessage = "Встреча добавлена.";
                navigation.NavigateTo(new ResultScreen(addMeetingMessage));
            }
            catch (Error.MeetingOnFuture)
            {
                Console.WriteLine(MeetingErrorConfig.AddToPastMeetingErrorMessage);
                Show();
            }
            catch (Error.MeetingsIntersects)
            {
                Console.WriteLine(MeetingErrorConfig.IntersectMeetingErrorMessage);
                Show();
            }
        }
    }
}

using System;

namespace MeetingManagement.Navigation
{
    public class EditMeetingScreen : Screen
    {
        private Meeting _meeting;
        private IMeetingService _meetingService;

        public EditMeetingScreen(Meeting meeting) : base()
        {
            _meeting = meeting;
            var repository = MeetingRepository.GetInstance();
            _meetingService = new MeetingService(repository);
        }

        public override void Show()
        {
            Console.Write("Введите описание: ");
            _meeting.Description = Console.ReadLine();
            Console.WriteLine($"Дата начала ({DatetimeConfig.DatetimeFormat})");
            var startTime = Console.ReadLine();
            Console.WriteLine($"Дата окончания ({DatetimeConfig.DatetimeFormat})");
            var endTime = Console.ReadLine();
            Console.WriteLine($"Время напоминания ({DatetimeConfig.DatetimeFormat})");
            var notificationTime = Console.ReadLine();

            _meeting.StartTime = DatetimeProvider.ParseDateToDatetimeFormat(startTime);
            _meeting.EndTime = DatetimeProvider.ParseDateToDatetimeFormat(endTime);
            _meeting.NotificationTime 
                = DatetimeProvider.ParseDateToDatetimeFormat(notificationTime);

            try
            {
                _meetingService.UpdateMeeting(_meeting);
                navigation.NavigateTo(new ResultScreen("Встреча обновлена."));
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

using System;

namespace MeetingManagement.Navigation
{
    public class MeetingScreen : Screen
    {
        private long _id;
        private IMeetingService _meetingService;

        public MeetingScreen(long id) : base()
        {
            _id = id;
            var repository = MeetingRepository.GetInstance();
            _meetingService = new MeetingService(repository);
        }

        public override void Show()
        {
            var meeting = _meetingService.GetMeeting(_id);
            Console.WriteLine($"Встреча: {meeting.Description}");
            Console.WriteLine("Начало в " 
                + $"{DatetimeProvider.ConvertToShortTimeString(meeting.StartTime)}");
            Console.WriteLine("Конец в " 
                + $"{DatetimeProvider.ConvertToShortTimeString(meeting.EndTime)}");
            Console.WriteLine("Напомнить в " 
                + $"{DatetimeProvider.ConvertToShortTimeString(meeting.NotificationTime)}");
            Console.WriteLine();

            const string editMeetingMenuItem = "1. Редактировать";
            Console.WriteLine(editMeetingMenuItem);
            const string deleteMeetingMenuItem = "2. Удалить";
            Console.WriteLine(deleteMeetingMenuItem);
            var selectedMenuItem = Console.ReadLine();

            switch (selectedMenuItem)
            {
                case "1":
                    var editMeetingScreen = new EditMeetingScreen(meeting);
                    navigation.NavigateTo(editMeetingScreen);
                    break;
                case "2":
                    _meetingService.DeleteMeeting(_id);
                    navigation.NavigateTo(new ResultScreen("Встреча удалена."));
                    break;
            }
        }
    }
}

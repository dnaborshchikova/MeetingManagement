using System;

namespace MeetingManagement.Navigation
{
    public class EnterDateScreen : Screen
    {
        public EnterDateScreen() : base()
        {

        }

        public override void Show()
        {
            Console.Write($"Введите дату ({DatetimeConfig.DateFormat}): ");
            var date = Console.ReadLine();
            var formattedDate = DatetimeProvider.ParseDateToDateFormat(date);

            navigation.NavigateTo(new MeetingsScreen(formattedDate));
        }
    }
}

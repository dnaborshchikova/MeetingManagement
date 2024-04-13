using System;

namespace MeetingManagement.Navigation
{
    public class MainScreen : Screen
    {
        public MainScreen() : base()
        {

        }

        public override void Show()
        {
            const string viewMeetingsMenuItem = "1. Посмотреть список встреч";
            Console.WriteLine(viewMeetingsMenuItem);

            const string addMeetingsMenuItem = "2. Добавить встречу";
            Console.WriteLine(addMeetingsMenuItem);
            var selectedMenuItem = Console.ReadLine();
            
            switch (selectedMenuItem)
            {
                case "1":
                    var enterDateScreen = new EnterDateScreen();
                    navigation.NavigateTo(enterDateScreen);
                    break;
                case "2":
                    var addMeetingScreen = new AddMeetingScreen();
                    navigation.NavigateTo(addMeetingScreen);
                    break;
            }
        }
    }
}

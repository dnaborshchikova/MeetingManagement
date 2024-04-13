using System;

namespace MeetingManagement.Navigation
{
    public class ResultScreen : Screen
    {
        private string _message;

        public ResultScreen(string message) : base()
        {
            _message = message;
        }

        public override void Show()
        {
            Console.WriteLine(_message);
            const string mainScreenMenuItem = "1. Вернуться на главный экран";
            Console.WriteLine(mainScreenMenuItem);

            var selectedMenuId = Console.ReadLine();

            switch(selectedMenuId)
            {
                case "1":
                    navigation.NavigateTo(new MainScreen());
                    break;
            }
        }
    }
}

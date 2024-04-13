using System;

namespace MeetingManagement.Navigation
{
    public class NavigationController
    {
        private Screen currentScreen;
        private static NavigationController instance;

        private NavigationController()
        {

        }

        public static NavigationController GetInstance()
        {
            if (instance == null)
            {
                instance = new NavigationController();
            }
            return instance;
        }

        public void NavigateTo(Screen screen)
        {
            currentScreen = screen;
            Console.Clear();
            currentScreen.Show();
        }
    }
}

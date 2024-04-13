using MeetingManagement.Navigation;

namespace MeetingManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            var navigation = NavigationController.GetInstance();
            var mainScreen = new MainScreen();
            navigation.NavigateTo(mainScreen);
        }
    }
}

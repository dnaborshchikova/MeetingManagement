namespace MeetingManagement.Navigation
{
    public abstract class Screen
    {
        protected NavigationController navigation;

        public Screen()
        {
            navigation = NavigationController.GetInstance();
        }

        public abstract void Show();
    }
}

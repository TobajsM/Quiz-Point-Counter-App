namespace Quiz_Point_Counter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(PointCountPage), typeof(PointCountPage));
            Routing.RegisterRoute(nameof(LeaderboardsPage), typeof(LeaderboardsPage));
        }
    }
}

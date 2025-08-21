using Quiz_Point_Counter.ViewModel;

namespace Quiz_Point_Counter;

public partial class LeaderboardsPage : ContentPage
{
	public LeaderboardsPage(Leaderboards p)
	{
		InitializeComponent();
		BindingContext = p;
	}
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Quiz_Point_Counter.Model;

namespace Quiz_Point_Counter.ViewModel;

[QueryProperty("Names", "Names")]
[QueryProperty("RoundNumber", "RoundNumber")]
public partial class PointCount : ObservableObject
{
    [ObservableProperty]
    int roundNumber;

    [ObservableProperty]
    ObservableCollection<Player> names;

    // Next Page
    [RelayCommand]
    async Task NextCounter()
    {
        CountPoints();
        await Shell.Current.GoToAsync($"{nameof(PointCountPage)}?RoundNumber={++roundNumber}",
                new Dictionary<string, object>
                {
                    { "Names", Names }
                });
    }

    // Finish the game
    [RelayCommand]
    async Task EndCounter()
    {
        bool confirm = await Shell.Current.DisplayAlert(
            "Finish quiz",
            "Are you sure?",
            "Yes", "No");

        if (confirm)
        {
            Sort();
            await Shell.Current.GoToAsync($"{nameof(LeaderboardsPage)}?RoundNumber={++roundNumber}",
                    new Dictionary<string, object>
                    {
                    { "Names", Names }
                    });
        }
    }

    // Update player score
    void CountPoints()
    {
        foreach (var player in Names)
        {
            player.AddPoints();
        }
    }

    void Sort()
    {
        var sorted = Names
            .OrderByDescending(p => p.Points)
            .ThenBy(p => p.Name)
            .ToList();

        int prev_points = -1;
        int index = 0;
        for (int i = 0; i < sorted.Count; i++)
        {
            if (sorted[i].Points != prev_points)
            {
                index++;
                prev_points = sorted[i].Points;
            }
            sorted[i].Position = index;
        }

        Names.Clear();
        foreach (var name in sorted)
        {
            Names.Add(name);
        }
    }

    // If user tapped on name, un/check the checkbox
    [RelayCommand]
    void ToggleCheck(Player player)
    {
        player.IsChecked = !player.IsChecked;
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quiz_Point_Counter.Model;
using System.Collections.ObjectModel;

namespace Quiz_Point_Counter.ViewModel;

[QueryProperty("Names", "Names")]
[QueryProperty("RoundNumber", "RoundNumber")]

public partial class Leaderboards : ObservableObject
{
    [ObservableProperty]
    int roundNumber;

    [ObservableProperty]
    ObservableCollection<Player> names;

    [RelayCommand]
    async Task Return()
    {
        Names.Clear();
        await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
    }
}

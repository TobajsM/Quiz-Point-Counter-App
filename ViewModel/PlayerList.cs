using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Quiz_Point_Counter.Model;

namespace Quiz_Point_Counter.ViewModel;

public partial class PlayerList : ObservableObject
{
    public PlayerList()
    {
        Names = new ObservableCollection<Player>();
    }

    [ObservableProperty]
    string name;

    [ObservableProperty]
    ObservableCollection<Player> names;

    [RelayCommand]
    void AddPlayer()
    {
        if (Name == null || Name.Length >= 24 || string.IsNullOrWhiteSpace(Name)) { return; }

        Names.Add(new Player { Name = Name });
        Name = string.Empty;
    }

    [RelayCommand]
    void RemovePlayer(Player name)
    {
        if (name != null)
        {
            Names.Remove(name);
        }
    }

    [RelayCommand]
    async Task GoTo()
    {
        if (Names.Count > 0)
        {
            await Shell.Current.GoToAsync($"{nameof(PointCountPage)}?RoundNumber={1}",
                new Dictionary<string, object>
                {
                    { "Names", Names }
                });
        }
    }
}

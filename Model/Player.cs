using CommunityToolkit.Mvvm.ComponentModel;

namespace Quiz_Point_Counter.Model;

public partial class Player : ObservableObject
{
    public Player()
    {
        isChecked = false;
        points = 0;
    }

    [ObservableProperty]
    string name;

    [ObservableProperty]
    bool isChecked;

    [ObservableProperty]
    int points;

    [ObservableProperty]
    int position;
    public void AddPoints()
    {
        if (isChecked)
        {
            points++;
            isChecked = false;
        }
    }
}

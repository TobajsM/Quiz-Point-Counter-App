using Quiz_Point_Counter.ViewModel;

namespace Quiz_Point_Counter
{
    public partial class MainPage : ContentPage
    {

        public MainPage(PlayerList p)
        {
            InitializeComponent();
            BindingContext = p;
        }
    }
}

using Quiz_Point_Counter.ViewModel;

namespace Quiz_Point_Counter
{
    public partial class PointCountPage : ContentPage
    {
        public PointCountPage(PointCount p)
        {
            InitializeComponent();
            BindingContext = p;
        }
    }
}
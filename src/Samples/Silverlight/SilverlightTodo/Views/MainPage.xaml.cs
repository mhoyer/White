using System.Windows.Controls;
using SilverlightTodo.ViewModels;

namespace SilverlightTodo.Views
{
    public partial class MainPage : UserControl
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}

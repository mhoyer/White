using System.Windows.Controls;
using SilverlightTodo.ViewModels;

namespace SilverlightTodo.Views
{
    public partial class AddTaskWindow : ChildWindow
    {
        public AddTaskWindow(AddTaskViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}


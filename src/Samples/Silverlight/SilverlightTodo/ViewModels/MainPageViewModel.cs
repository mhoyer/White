using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SilverlightTodo.Models;
using SilverlightTodo.Views;

namespace SilverlightTodo.ViewModels
{
    public class MainPageViewModel
    {
        AddTaskWindow _addTaskWindow;
        public ICommand AddTaskCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }
        public ObservableCollection<Task> Tasks { get; set; }

        public MainPageViewModel()
        {
            AddTaskCommand = new DelegateCommand(AddTask);
            DeleteTaskCommand = new DelegateCommand<Task>(DeleteTask);
            Tasks = new ObservableCollection<Task>();
        }

        void DeleteTask(Task task)
        {
            Tasks.Remove(task);
        }

        void AddTask()
        {
            var addTaskViewModel = new AddTaskViewModel();
            addTaskViewModel.OnCancel += OnAddTaskCancel;
            addTaskViewModel.OnCreate += OnAddTaskCreate;

            _addTaskWindow = new AddTaskWindow(addTaskViewModel);
            _addTaskWindow.Show();
        }

        void OnAddTaskCancel(object sender, EventArgs e)
        {
            CloseAddTaskWindow();
        }

        void OnAddTaskCreate(object sender, CreateTaskEventArgs args)
        {
            Tasks.Add(args.NewTask);

            CloseAddTaskWindow();
        }

        void CloseAddTaskWindow()
        {
            if (_addTaskWindow == null) return;

            _addTaskWindow.Close();
            _addTaskWindow = null;
        }
    }
}
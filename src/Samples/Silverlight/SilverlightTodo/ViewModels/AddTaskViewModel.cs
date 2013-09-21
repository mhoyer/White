using System;
using System.Windows.Input;
using SilverlightTodo.Models;

namespace SilverlightTodo.ViewModels
{
    public class AddTaskViewModel
    {
        public Task NewTask { get; set; }
        public ICommand CreateCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public event EventHandler OnCancel;
        public event EventHandler<CreateTaskEventArgs> OnCreate;

        public AddTaskViewModel() : this(new Task()) { }
        public AddTaskViewModel(Task newTask)
        {
            NewTask = newTask;
            CancelCommand = new DelegateCommand(RaiseOnCancel);
            CreateCommand = new DelegateCommand(RaiseOnCreate);
        }

        void RaiseOnCancel()
        {
            if (OnCancel != null) OnCancel(this, EventArgs.Empty);
        }

        void RaiseOnCreate()
        {
            if (OnCreate != null) OnCreate(this, new CreateTaskEventArgs(NewTask));
        }
    }
}

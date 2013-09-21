using System;
using SilverlightTodo.Models;

namespace SilverlightTodo
{
    public class CreateTaskEventArgs : EventArgs
    {
        public Task NewTask { get; private set; }

        public CreateTaskEventArgs(Task newTask)
        {
            NewTask = newTask;
        }
    }
}

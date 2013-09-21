using System;
using System.Windows.Input;

namespace SilverlightTodo
{
    public class DelegateCommand : ICommand
    {
        readonly Action _execute;
        readonly Func<bool> _canExecute;

        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;

            return _canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }

    public class DelegateCommand<TParam> : ICommand
    {
        readonly Action<TParam> _execute;
        readonly Func<TParam, bool> _canExecute;

        public DelegateCommand(Action<TParam> execute, Func<TParam, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;

            return _canExecute.Invoke((TParam)parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke((TParam)parameter);
        }

        public event EventHandler CanExecuteChanged;
    }

}
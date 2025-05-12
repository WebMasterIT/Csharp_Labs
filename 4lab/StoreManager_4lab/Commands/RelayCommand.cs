using System;
using System.Windows.Input;

<<<<<<< HEAD
namespace StoreManager_4lab.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        //private readonly Predicate<object> _canExecute;

        private readonly Func<object, bool> _canExecute;



        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _execute(parameter);
    }
}
  
=======
public class RelayCommand : ICommand
{
    private readonly Action<object> _execute; // делегат выполнения команды
    private readonly Func<object, bool> _canExecute; // делегат проверки возможности выполнения команды

    // Конструктор команды
    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute)); // инициализация метода выполнения
        _canExecute = canExecute; // инициализация метода проверки доступности
    }

    // Событие, которое вызывается при изменении условий выполнения команды
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    // Проверка, может ли команда быть выполнена
    public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

    // Выполнение команды
    public void Execute(object parameter) => _execute(parameter);
}
>>>>>>> c79e983c4cab3c416e44b6d5f9854b292fdeae26

﻿using System;
using System.Windows.Input;

namespace TinyInstaller.Common
{
    internal class RelayCommand : ICommand
    {
        private readonly Predicate<object> canExecuteDelegate;

        private readonly Action<object> executeDelegate;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            executeDelegate = execute;
            canExecuteDelegate = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => canExecuteDelegate is null || canExecuteDelegate.Invoke(parameter);

        public void Execute(object parameter) => executeDelegate?.Invoke(parameter);
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EFCore_MPS.Core
{
    internal class RelayCommand<T>: ICommand
    {
        private Action<T> _execute;
        private Func<object, bool> _canExecute;
        

        //public RelayCommand(Action<T> execute)
        //    : this(execute, null)
        //{

        //}


        public RelayCommand(Action<T> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}

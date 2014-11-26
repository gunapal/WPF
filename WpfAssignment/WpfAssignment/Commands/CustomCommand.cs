// -----------------------------------------------------------------------
// <copyright file="DelegateCommand.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WpfAssignment.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;

    public class CustomCommand : ICommand
    {
        #region Call Back delegates
        
        Func<object, bool> _canExecuteFunc;
        Action<object> _executeAction;

        #endregion

        #region Constructor

        public CustomCommand(Action<object> executeAction) : this(executeAction, null)
        {
            
        }

        public CustomCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            _executeAction = executeAction;
            _canExecuteFunc = canExecuteFunc;
        }

        #endregion

        #region ICommand Implementation

        public bool CanExecute(object parameter)
        {
            if (_canExecuteFunc == null && _executeAction != null)
            {
                return true;
            }

            return _canExecuteFunc(parameter);
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TasksManager.Helper
{
    /// <summary>
    /// Command button for callback binding
    /// </summary>
    public class TaskButtonCommand : ICommand
    {
        private readonly Action _buttonHandler;
        private readonly Action<object> _buttonHandlerWithParam;
        private Func<bool> _canExecute;

        public TaskButtonCommand(Action handler)
        {
            this._buttonHandler = handler;
        }

        public TaskButtonCommand(Action handler, Func<bool> canExecute)
        {
            this._buttonHandler = handler;
            this._canExecute = canExecute;
        }

        public TaskButtonCommand(Action<object> handler, Func<bool> canExecute)
        {
            this._buttonHandlerWithParam = handler;
            this._canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {

            if (_canExecute != null)
            {
                return _canExecute();
            }

            if (_buttonHandler != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            //used when command parameters given
            if (parameter != null)
            {
                _buttonHandlerWithParam(parameter);
            }
            else
            {
                _buttonHandler();
            }
        }
    }


}

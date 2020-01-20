using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.Helper;
using TasksManager.Models;

namespace TaskManager.ViewModels
{
    public class TaskEditViewModel : IBaseViewModel
    {

        public TaskEditViewModel()
        { 
            TaskButtonOkClick = new TaskButtonCommand(this.OkClick, this.CanOKWindow);
            TaskButtonCancelClick = new TaskButtonCommand(this.CancelClick, this.CanCancelWindow);
        }

        public TasksManager.Models.Task EditTask { get; set; }

        private TasksManager.Models.Task _selectedTask;
        public TasksManager.Models.Task SelectedTask
        {
            get
            {
                return _selectedTask;
            }
            set
            {
                _selectedTask = value;

                this.EditTask = new TasksManager.Models.Task
                {
                    TaskName = _selectedTask.TaskName,
                    DueDate = _selectedTask.DueDate
                };

                //inform when edit item text changed
                EditTask.PropertyChanged += (s, e) => { TaskButtonOkClick.RaiseCanExecuteChanged(); };
            }
        }

        public TaskButtonCommand TaskButtonCancelClick { get; set; }
        private bool CanCancelWindow()
        {
            return true;
        }
        private void CancelClick(object param)
        {
            if (param is System.Windows.Window)
            {
                this.EditTask = null;
                (param as System.Windows.Window).Close();
            }
        }

        public TaskButtonCommand TaskButtonOkClick { get; set; }

        private bool CanOKWindow()
        {
            return !string.IsNullOrEmpty(this.EditTask.TaskName);
        }

        private void OkClick(object param)
        {
            if (param is System.Windows.Window)
            {
                _selectedTask.TaskName = this.EditTask.TaskName;
                _selectedTask.DueDate = this.EditTask.DueDate;
                
                this.EditTask = null;

                (param as System.Windows.Window).Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.Helper;

namespace TasksManager.Models
{
    /// <summary>
    /// Model represents the Task object
    /// </summary>
    public class Task : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Model
        private string taskName;
        private bool isComplete = false;
        private DateTime dueDate = DateTime.Now.AddDays(1);
        private Status taskStatus;

        public string TaskName
        {
            get
            {
                return taskName;
            }
            set
            {
                taskName = value;
                RaisePropertyChanged("TaskName");
            }
        }
        
        public bool IsComplete
        {
            get { return isComplete; }
            set
            {
                isComplete = value;
                RaisePropertyChanged("IsComplete");

                EvaluateTaskStatus();
            }
        }

        public Status TaskStatus
        {
            get { return taskStatus; }
            set
            {
                taskStatus = value;
                RaisePropertyChanged("TaskStatus");
            }
        }

        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                RaisePropertyChanged("DueDate");

                EvaluateTaskStatus();
            }
        }

        private void EvaluateTaskStatus()
        {
            if (DueDate < DateTime.Now && !IsComplete)
            {
                TaskStatus = Status.Overdue;
            }
            else
            {
                TaskStatus = isComplete ? Status.Complete : Status.Incomplete;
            }
        }
        #endregion

        #region Notify Property changes
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion

        #region Error Handlers
        public string Error => null;

        public string this[string columnName]
        {

            get
            {
                if (columnName == "TaskName")
                {
                    if (string.IsNullOrEmpty(TaskName))
                    {
                        return "Task name is required";
                    }
                }

                return null;
            }
        }

        #endregion
    }
}

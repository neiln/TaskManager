using System;
using System.Collections.ObjectModel;
using TaskManager.Services;
using TaskManager.ViewModels;
using TasksManager.Helper;

namespace TasksManager.ViewModels
{
    /// <summary>
    /// ViewModel for the Todo
    /// </summary>
    public class TaskViewModel : IBaseViewModel
    {
        private DialogWindowService _dialogService;
        public TaskViewModel()
        {
            //register this vm with the service
            _dialogService = new DialogWindowService(this);

            TaskButtonAddClick = new TaskButtonCommand(this.AddItem, this.CanAddItem);
            TaskButtonEditClick = new TaskButtonCommand(this.EditItem, this.CanEditItem);
            TaskButtonRemoveClick = new TaskButtonCommand(this.RemoveItem, this.CanRemoveItem);
 
            NewTask = new Models.Task();
            NewTask.PropertyChanged += (s, e) => { TaskButtonAddClick.RaiseCanExecuteChanged(); };

            //Tasks = new ObservableCollection<Models.Task>();

            //load sample tasks
            LoadTasks();

        }



        public ObservableCollection<Models.Task> Tasks { get; set; }

        public void LoadTasks()
        {
            Tasks = new ObservableCollection<Models.Task>
            {
                new Models.Task { TaskName = "Climb mount Kilimanjaro", DueDate= DateTime.Now.AddDays(120) },
                new Models.Task { TaskName = "Get book signed by Roger Edwards", DueDate= DateTime.Now.AddDays(-1) },
                new Models.Task { TaskName = "Read 'The City We Became'", DueDate= DateTime.Now.AddDays(-20), IsComplete=true},
                new Models.Task { TaskName = "Get groceries", DueDate= DateTime.Now.AddDays(3) }
            };

        }

        #region Add Item
        public TaskButtonCommand TaskButtonAddClick { get; set; }
        private bool CanAddItem()
        {
            return !string.IsNullOrEmpty(NewTask.TaskName);
        }
        private void AddItem()
        {
            this.SelectedTask = null;
           
            Models.Task task = new Models.Task();
            task.TaskName = NewTask.TaskName;
            task.DueDate = NewTask.DueDate;

            Tasks.Add(task);

            NewTask.TaskName = string.Empty;
            NewTask.DueDate = DateTime.Now.AddDays(1);

        }
        #endregion


        #region Edit Item
        public TaskButtonCommand TaskButtonEditClick { get; set; }
        private bool CanEditItem()
        {
            return SelectedTask != null;
        }
        private void EditItem()
        {
            _dialogService.ShowEditDialog();
        }
        #endregion


        #region Remove Item
        public TaskButtonCommand TaskButtonRemoveClick { get; set; }
        private bool CanRemoveItem()
        {
            return SelectedTask != null;
        }
        private void RemoveItem()
        {
            Tasks.Remove(SelectedTask);
        }
        #endregion


        public Models.Task NewTask
        {
            get; set;
        }

        private Models.Task _selectedTask;

        public Models.Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;

                //inform buttons about item selection
                TaskButtonRemoveClick.RaiseCanExecuteChanged();
                TaskButtonEditClick.RaiseCanExecuteChanged();
            }
        }

       
    }
}

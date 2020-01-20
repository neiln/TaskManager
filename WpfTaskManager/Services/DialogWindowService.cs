using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ViewModels;
using TaskManager.Views;
using TasksManager.ViewModels;

namespace TaskManager.Services
{
    public interface IEditDialogService
    {
        void ShowEditDialog();
    }

    public class DialogWindowService : IEditDialogService
    {
        private IBaseViewModel _viewModel;

        public DialogWindowService(IBaseViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void ShowEditDialog()
        {
            TaskEditViewModel vm = new TaskEditViewModel();
            if (_viewModel is TaskViewModel)
            {
                vm.SelectedTask = (_viewModel as TaskViewModel).SelectedTask;
                TaskEditWindow taskEditWindow = new TaskEditWindow(vm);

                taskEditWindow.ShowDialog();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksManager.ViewModels
{
    public class MainWindowViewModel
    {
        /// <summary>
        /// App Title
        /// </summary>
        public string Title {
            get { return "Task Manager"; }
        }

        /// <summary>
        /// Returns today's date in formatted string
        /// </summary>
        public string Today {
            get {
                return DateTime.Today.ToString("dddd, dd MMMM yyyy");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using static TasksManager.Models.Task;

namespace TasksManager.Helper
{
    /// <summary>
    /// Converts task status to a color brush for display
    /// </summary>
    class TaskStatusValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.Black);

            switch ((Status)value)
            {
                case Status.Complete:
                    brush.Color = Colors.LawnGreen;
                    break;
                case Status.Overdue:
                    brush.Color = Colors.Coral;
                    break;
                case Status.Incomplete:
                default:
                    brush.Color = Colors.Transparent;
                    break;

            }

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

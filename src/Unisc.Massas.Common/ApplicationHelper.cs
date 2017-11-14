using System;
using System.Windows;
using System.Windows.Threading;

namespace Unisc.Massas.Core
{
    public static class ApplicationHelper
    {
        public static void ExecuteAction(Action action)
        {
            Application.Current.Dispatcher.BeginInvoke(action, DispatcherPriority.Background);
        }
    }
}

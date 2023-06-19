using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_MPS.Core
{
    class DialogService : IDialogService
    {
        public void ShowDialog(string nameWindow)
        {
            var type = Type.GetType($"EFcore_MPS.View.{nameWindow}");
        }

        public void ShowDialog(string nameWindow, Action<string, object> callback)
        {
            var dialog = new DialogWindow();

            var type = Type.GetType($"EFcore_MPS.View.{nameWindow}");

            dialog.Content = Activator.CreateInstance( type );

            dialog.ShowDialog();
             
        }
    }
}

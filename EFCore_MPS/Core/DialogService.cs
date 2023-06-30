using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_MPS.Core
{
    class DialogService : IDialogService
    {
       
        /// <summary>
        /// Represents functionality to open dialog window with different xaml-markup
        /// </summary>
        /// <param name="nameWindow"></param>
        /// <param name="callback"></param>
        public void ShowDialog(string nameWindow, Action<string, object> callback)
        {
            var dialog = new DialogWindow();

            EventHandler closeEventHandler= null;
            closeEventHandler = (s, e) =>
            {
                callback(dialog.DialogResult.ToString(), dialog.ObjectToDbSave);
                dialog.Closed -= closeEventHandler;
            };

            dialog.Closed += closeEventHandler;

            var type = Type.GetType($"EFCore_MPS.DialogWindows.{nameWindow}");

            dialog.Content = Activator.CreateInstance(type);

            dialog.ShowDialog();
             
        }

        public void ShowDialog(string v)
        {
            throw new NotImplementedException();
        }
    }
}

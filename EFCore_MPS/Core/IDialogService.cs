using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_MPS.Core
{
    interface IDialogService
    {
        public void ShowDialog(string nameWindow, Action<string,object> callback);
    }
}

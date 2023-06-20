using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EFCore_MPS
{
    /// <summary>
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        protected object _objectToDbSave;
        public object ObjectToDbSave
        {
            get { return _objectToDbSave; }
            set { _objectToDbSave = value; }
        }
        public DialogWindow()
        {
            InitializeComponent();
            _objectToDbSave = new object();
        }
    }
}

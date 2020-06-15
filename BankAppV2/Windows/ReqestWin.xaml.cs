using BankAppV2.Presenter;
using BankAppV2.View;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace BankAppV2.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReqestWin.xaml
    /// </summary>
    public partial class ReqestWin : Window, IViewRequest
    {

        PresenterRequest p;
        public ReqestWin(IEnumerable<object> dt)
        {
            InitializeComponent();
            p = new PresenterRequest(this);
            AutoGrid.DataContext = dt;
            Open.Click +=(s,e) => p.Open();
            Close.Click += (s, e) => this.Close();
        }

        public string Status { get => Status_TB.Text; }
      
        public DataTable dataTable { set => AutoGrid.DataContext = value.DefaultView; }

        public string NumPass { get => NumPas_TB.Text; }

        public string NumInn { get =>NumINN_TB.Text; }
    }
}

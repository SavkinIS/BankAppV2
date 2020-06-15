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
    /// Логика взаимодействия для DataWinClient.xaml
    /// </summary>
    public partial class DataWinClient : Window, IViewData
    {
        PresenterDataClien pd;
        public DataWinClient()
        {
            InitializeComponent();
        
            pd = new PresenterDataClien(this);

            AutoGrid.Loaded += (s, e) => AutoGrid.DataContext = pd.LoaderData();
            Close.Click += (s, e) => this.Close();
            Delete.Click += (s, e) => pd.DeleteClient();
            Change.Click += (s, e) => pd.ChangeClientInfo();
            Open.Click += (s, e) => pd.OpenClientCash();


        }

        public string Status { get => Status_TB.Text; }
        public string NumPassOrInn { get => NumPas_TB.Text; }
        public List<Client> dataTable { set => AutoGrid.DataContext = value; }
    }
}

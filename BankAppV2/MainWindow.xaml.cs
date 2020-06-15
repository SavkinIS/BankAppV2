using BankAppV2.HelperClass;
using BankAppV2.Presenter;
using BankAppV2.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankAppV2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainView 
    {
        MainPresenter p;
        public MainWindow()
        {
            
            p = new MainPresenter(this);

            InitializeComponent();
            Combo.ItemsSource = p.types.Types;
            NewClient_Bn.Click += (s, e) => p.OpenNewClient();
            Client_Bn.Click += (s, e) => p.PeopleClient();
            Company_Bn.Click += (s, e) => p.CompanyClient();
            Find_Bn.Click += (s, e) => p.Sample();
            NewClientComp_Bn.Click += (s, e) => p.OpenNewClientComp();
        }

        public string Request { get => Cb_Value.Text; }
        public string About { get => Request_Tbx.Text; }
    }



   /*
    * Реализовать расчет кредита, вклада
    * 
    * 
    */
}

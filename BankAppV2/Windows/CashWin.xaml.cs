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
    /// Логика взаимодействия для CashWin.xaml
    /// </summary>
    public partial class CashWin : Window , IViewCashApp
    {
        string st = "";
        string nm = "";

        PresenterCashAcc p;
        public CashWin(string status, string num )
        {
            st = status;
            nm = num; 
            InitializeComponent();
            p = new PresenterCashAcc(this);
            NewCashAcc.Click += (s, e) => p.NewCashAcc() ;
            Bn_Credit.Click += (s, e) => p.CreateCredit();
            Bn_Deposit.Click += (s, e) => p.OpenDeposit();
            Bn_transfer.Click += (s, e) => p.TransClientsCashAcc();
            Bn_transferToUser.Click += (s, e) => p.TarnsOtherClients();
            Bn_Delete.Click += (s, e) => p.DeleteCashAcc();
            DG_CashAcc.Loaded += (s, e) => DG_CashAcc.DataContext = p.Loader();
           

        }



        public string Status => st;
        public string NumPassOrInn => nm;

        public List<CashAccounts> dataTable {set => DG_CashAcc.DataContext = value; }

        public string CashNum => CashNum_TB.Text;
    }
}

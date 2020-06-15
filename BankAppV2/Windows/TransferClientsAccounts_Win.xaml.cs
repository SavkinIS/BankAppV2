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
using System.Windows.Shapes;

namespace BankAppV2.Windows
{
    /// <summary>
    /// Логика взаимодействия для TransferClientsAccounts_Win.xaml
    /// </summary>
    public partial class TransferClientsAccounts_Win : Window , IViewTransferClientsAcc
    {
        string num = "";
        PresenterTransferClAcc p;
        public TransferClientsAccounts_Win(string numCsh, string numCl, string status)
        {
            num = numCsh;
            p = new PresenterTransferClAcc(this);
            InitializeComponent();

            Sum_Transfer.PreviewKeyDown += (s, e) => p.Validation(e, s);
            Bt_trans.Click += (s, e) => p.Trans();
            this.Loaded += (s, e)=> p.Loader();
            Combo_Selected_Acc.ItemsSource = p.CashList( numCl, status);
            Combo_Selected_Acc.DropDownClosed += (s, e) => p.TakeFinance();
        }

        public string CurentAcc { get => CurentAcc = num;  set => Current_Acc.Text = num; }
        public string CurentFinance { get => Current_Finance.Text; set => Current_Finance.Text = value; }
        public string SelectedFinance { get => Selected_Finance.Text; set => Selected_Finance.Text = value; }
        public string SumTransfer { get => Sum_Transfer.Text; set => Sum_Transfer.Text = value; }
       // public string NumCashAcc { set => throw new NotImplementedException(); }
       // public string Status => throw new NotImplementedException();
        public string SelectedAcc { get => ComboSelect.Text; set => ComboSelect.Text = value; }
    }
}

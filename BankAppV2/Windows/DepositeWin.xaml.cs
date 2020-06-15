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
using System.Windows.Shapes;

namespace BankAppV2.Windows
{
    /// <summary>
    /// Логика взаимодействия для DepositeWin.xaml
    /// </summary>
    public partial class DepositeWin : Window, IViewDeposite
    {
        PresenterDepositecs p;
        public DepositeWin(string numCl, string status)
        {
            InitializeComponent();
            p = new PresenterDepositecs(this);
            this.Loaded += (s, e) => p.Loader(numCl, status);
            Combo_Selected_type.ItemsSource = p.li;
            Open_bt.Click += (s, e) =>  p.Open(numCl, status);
            Conculate_bt.Click += (s, e) => p.Conculate();
            Tbx_SumIn.PreviewKeyDown += (s, e) => Validators.Validinput(e, s);
            Tbx_time.PreviewKeyDown += (s, e) => Validators.Validinput(e, s);
        }

        public string SumDep { get => Tbx_SumIn.Text; set => Tbx_SumIn.Text = value; }
        public string TypeDep { get => Combo_Selected_type.SelectedItem.ToString() ; set => Combo_Selected_type.SelectedIndex = Convert.ToInt32(value); }
        public string MonthsDep { get => Tbx_time.Text; set => Tbx_time.Text = value; }
        public string FinanceEnd { get => Finance_after_time.Text; set => Finance_after_time.Text = value; }
        public string Rating { get => Tb_Rating.Text; set => Tb_Rating.Text = value; }
        public string Procents { get => Tb_Procents.Text; set => Tb_Procents.Text = value; }
    }
}

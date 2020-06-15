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
    /// Логика взаимодействия для CreditWin.xaml
    /// </summary>
    public partial class CreditWin : Window, IViewCredit 
    {
        PresenterCredit p;

        public CreditWin(string NumDoc, string status)
        {
            InitializeComponent();
            p = new PresenterCredit(this);

            this.Loaded += (s, e) => p.Loader(NumDoc, status);
            Tbx_SumCredit.PreviewKeyDown += (s, e) => p.Validation(e, s);
            Tbx_period.PreviewKeyDown += (s, e) => p.Validation(e, s);
            Give.Click += (s, e) => { p.Give(NumDoc, status);};
            Calculate.Click += (s, e) => p.Calculate();
        }

        public string SumCredit { get => Tbx_SumCredit.Text; set => Tbx_SumCredit.Text = value; }
        public string Months { get => Tbx_period.Text; set => Tbx_period.Text = value; }
        public string PayFormonth { get => Tb_PayforMonth.Text; set => Tb_PayforMonth.Text = value; }
        public string EndProcent { get => Tb_Procent.Text; set => Tb_Procent.Text = value; }
        public string Rating { get => Tb_rating.Text; set => Tb_rating.Text = value; }
    }
}

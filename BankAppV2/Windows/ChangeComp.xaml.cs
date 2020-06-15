using BankAppV2.HelperClass;
using BankAppV2.Presenter;
using BankAppV2.View;
using MyExtention;
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
    /// Логика взаимодействия для ChangeComp.xaml
    /// </summary>
    public partial class ChangeComp : Window, IViewAddCompany
    {
        PresenterAddCompany p;
        string lName = "";
        
        Company client;
        public ChangeComp(Company cli)
        {
            client = cli;
            p = new PresenterAddCompany(this);
            InitializeComponent();
            this.Loaded += (s, e) => p.Loader();
            Cb_Status.ItemsSource = p.clStat.LiCom;
            NumInn.PreviewKeyDown += (s, e) => p.Validinput(e, s);
            NumInn.LostFocus += (s, e) => p.Check();
            AllCash.PreviewKeyDown += (s, e) => p.Validinput(e, s);
            Bt_Rating.KeyDown += (s, e) => p.Validinput(e, s);
            // AllCash.KeyDown += (s, e) => p.Validinput(e, s);


            Change.Click += (s, e) => { p.Change(); this.Close(); };

        }

        public string NumbInn { get => NumInn.Text; set => NumInn.Text = value; }
        public string Status { get => ((ClientStatus)Cb_Status.SelectedItem).Status; set => Cb_Status.SelectedIndex = value.ToInt32(); }

        public string CompName { get => FstName.Text; set => FstName.Text = value; }

       

        public string Finance { get => AllCash.Text; set => AllCash.Text = value; }

        public string Adress { get => Tb_Adres.Text; set => Tb_Adres.Text = value; }

        public string Rating { get => Bt_Rating.Text; set => Bt_Rating.Text = value; }

        public string WorkPlace { get => ""; set => lName = value; }

        public DateTime CreateDay { get => BrthDay.DisplayDate; set => BrthDay.DisplayDate = value; }

        public Company co { get => client; }
    }
}

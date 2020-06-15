using BankAppV2.HelperClass;
using BankAppV2.Presenter;
using BankAppV2.View;
using MyExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для ChangeClient.xaml
    /// </summary>
    public partial class ChangeClient : Window, IViewAddClient
    {
        PresenterAddClient p;
        Client client;
        public ChangeClient(Client cli)
        {
            
            client = cli;
            p = new PresenterAddClient(this);
            InitializeComponent();

            this.Loaded +=(s,e)=> p.Loader();
            Cb_Status.ItemsSource = p.clStat.Li;
            NumPassport.PreviewKeyDown += (s, e) => p.Validinput(e, s);
            NumPassport.LostFocus += (s, e) => p.Check();
            AllCash.PreviewKeyDown += (s, e) => p.Validinput(e, s);
            Bt_Rating.KeyDown += (s, e) => p.Validinput(e, s);
            AllCash.KeyDown += (s, e) => p.Validinput(e, s);
            //Tb_Adres.GotFocus += (s, e) => Tb_Adres.Text = "";
            //Tbk_Work.GotFocus += (s, e) => Tbk_Work.Text = "";
            Change.Click += (s, e) => { p.Change(); this.Close(); };
           

        }


        public string NumDoc { get => NumPassport.Text; set => NumPassport.Text = value; }
        public string Status { get => ((ClientStatus)Cb_Status.SelectedItem).Status; set => Cb_Status.SelectedIndex = value.ToInt32(); }

        public string FName { get => FstName.Text; set => FstName.Text = value; }

        public string LName { get => LstName.Text; set => LstName.Text = value; }

        public string Finance { get => AllCash.Text; set => AllCash.Text = value; }

        public string Adress { get => Tb_Adres.Text; set => Tb_Adres.Text = value; }

        public string Rating { get => Bt_Rating.Text; set => Bt_Rating.Text = value; }

        public string WorkPlace { get => Tbk_Work.Text; set => Tbk_Work.Text = value; }

        public DateTime brthDay { get => BrthDay.DisplayDate; set => BrthDay.DisplayDate = value; }

        public Client cl { get => client; }
    }
}

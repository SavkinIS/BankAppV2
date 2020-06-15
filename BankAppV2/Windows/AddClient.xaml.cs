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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window , IViewAddClient
    {
        PresenterAddClient p;
        public AddClient()
        {
            p = new PresenterAddClient(this);
            InitializeComponent();
            Cb_Status.ItemsSource = p.clStat.Li;
            NumPassport.PreviewKeyDown += (s, e) => p.Validinput(e, s);
            NumPassport.LostFocus += (s, e) => p.Check();
            //AllCash.PreviewKeyDown += (s, e) => p.Validinput(e, s);
            Bt_Rating.KeyDown += (s, e) => p.Validinput(e, s);
            AllCash.KeyDown+=(s,e)=> p.Validinput(e, s);
            Tb_Adres.GotFocus += (s, e) => p.AdressLostFocus();
            NumPassport.GotFocus += (s, e) => p.NumDocLostFocus();
            Tbk_Work.GotFocus += (s, e) => p.WorkPlaceLostFocus() ;
            Tb_Adres.LostFocus += (s, e) => p.AdressLostFocus();
            NumPassport.LostFocus += (s, e) => p.NumDocLostFocus();
            Tbk_Work.LostFocus += (s, e) => p.WorkPlaceLostFocus();
            Add.Click += (s, e) => p.AddClient();
            //Bt_deposit.ItemsSource = list;
        }


        public string NumDoc { get => NumPassport.Text; set => NumPassport.Text = value; }
        public string Status { get => ((HelperClass.ClientStatus)Cb_Status.SelectedItem).Status; set => throw new NotImplementedException(); }

        public string FName { get => FstName.Text; set => FstName.Text = value; }

        public string LName { get => LstName.Text; set=> throw new NotImplementedException(); }

        public string Finance { get => AllCash.Text;  set=> throw new NotImplementedException(); }

        public string Adress { get => Tb_Adres.Text;  set=> Tb_Adres.Text = value; }

        public string Rating { get => Bt_Rating.Text;  set=> throw new NotImplementedException(); }

        public string WorkPlace { get => Tbk_Work.Text;  set=> Tbk_Work.Text = value; }

        public DateTime brthDay { get => BrthDay.DisplayDate;  set=> throw new NotImplementedException(); }

        public Client cl => new Client();

        List<string> list = new List<string> { "Москва", "Воронеж", "Перьмь", "Омск","Мосальск" };
    }
}

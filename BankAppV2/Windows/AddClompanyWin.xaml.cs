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
    /// Логика взаимодействия для AddClompanyWin.xaml
    /// </summary>
    public partial class AddClompanyWin : Window, IViewAddCompany
    {
        PresenterAddCompany p;
        public AddClompanyWin()
        {
            InitializeComponent();
            p = new PresenterAddCompany(this);
            
            Cb_Status.ItemsSource = p.clStat.LiCom;
            NumInn.PreviewKeyDown += (s, e) => p.Validinput(e, s);
            NumInn.LostFocus += (s, e) => p.Check();
            AllCash.PreviewKeyDown += (s, e) => p.Validinput(e, s);
            Bt_Rating.KeyDown += (s, e) => p.Validinput(e, s);
            AllCash.KeyDown += (s, e) => p.Validinput(e, s);
            Tb_Adres.GotFocus += (s, e) => p.AdressLostFocus();
            NumInn.GotFocus += (s, e) => p.NumDocLostFocus();
            Tb_Adres.LostFocus += (s, e) => p.AdressLostFocus();
            NumInn.LostFocus += (s, e) => p.NumDocLostFocus();


            Add.Click += (s, e) => p.AddClient();
        }

        public string NumbInn { get => NumInn.Text; set => NumInn.Text = value; }
        public string Status { get => ((HelperClass.ClientStatus)Cb_Status.SelectedItem).Status; set => throw new NotImplementedException(); }

        public string FName { get => FstName.Text; set => throw new NotImplementedException(); }

        public string CompName { get => FstName.Text; set => throw new NotImplementedException(); }

        public string Finance { get => AllCash.Text; set => throw new NotImplementedException(); }

        public string Adress { get => Tb_Adres.Text; set => Tb_Adres.Text = value; }

        public string Rating { get => Bt_Rating.Text; set => throw new NotImplementedException(); }

       

        public DateTime CreateDay { get => BrthDay.DisplayDate; set => throw new NotImplementedException(); }

        public Company co => new Company();

      

       

        List<string> list = new List<string> { "Москва", "Воронеж", "Перьмь", "Омск", "Мосальск" };

        
    }
}

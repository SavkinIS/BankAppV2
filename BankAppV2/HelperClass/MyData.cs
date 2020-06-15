using MyExtention;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankAppV2.HelperClass
{


    /// <summary>
    /// Класс взаимодействия с БД
    /// </summary>
    class MyData
    {
        static DataTable dtDataWin;
        static SqlDataAdapter daForDataWin = new SqlDataAdapter();
        
        static SqlDataAdapter daForCashWin = new SqlDataAdapter();
        static SqlConnectionStringBuilder strCon;

        ClientDescription cd = new ClientDescription();


        public MyData()
        {
            try
            {
                string main_fol = "SkillBoxDB.mdf";
                string parent = Directory.GetParent("SkillBoxDB.mdf").ToString();
                string paht = @parent + @"\" + main_fol;
                // Создаем Строку подключения
                strCon = new SqlConnectionStringBuilder()
                {

                    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mrsaw\OneDrive\Документы\SkillBoxDB.mdf;Integrated Security=True;Connect Timeout=30
                    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="D:\C#\skillbox\Курс от нуля до про\Модуль 17\NewV2\SkillBoxDB.mdf";Integrated Security=True;Connect Timeout=30
                    DataSource = @"(localDB)\MSSQLLocalDB",
                    AttachDBFilename = paht,

                };
            }
            catch (Exception e) { MessageBox.Show(e.Message); }


        }


        /// <summary>
        ///  Мептод выводит все Компании из базы
        /// </summary>
        /// <returns></returns>
        public DataTable PrintData()
        {
            dtDataWin = new DataTable();

            using (var con = new SqlConnection(strCon.ConnectionString))
            {
                try
                {
                    string sql = $"SELECT * FROM Company";
                    UpdateDt(con, sql);
                }
                catch (Exception e) { MessageBox.Show(e.Message); }
            }


                return dtDataWin;
        }


        /// <summary>
        ///  Мептод выводит все Компании из базы
        /// </summary>
        /// <returns></returns>
        public DataTable PrintDataClient()
        {
            dtDataWin = new DataTable();

            using (var con = new SqlConnection(strCon.ConnectionString))
            {
                try
                {
                    string sql = $"SELECT * FROM Client";
                    UpdateDt(con, sql);
                }
                catch (Exception e) { MessageBox.Show(e.Message); }
            }


            return dtDataWin;
        }

        /// <summary>
        /// Метод обновляет dtDataWin соответственно запросу
        /// </summary>
        /// <param name="con">SqlConnection</param>
        /// <param name="sql">Sql запрос</param>
        private static void UpdateDt(SqlConnection con, string sql)
        {
            daForDataWin.SelectCommand = new SqlCommand(sql, con);
            daForDataWin.Fill(dtDataWin);
        }

        
        /// <summary>
        /// Открывает новый счет с пустым балансом
        /// </summary>
        /// <param name="status"></param>
        /// <param name="num"></param>
        public void NewCashAcc(string status, string num)
        {
            string inn = "";
            string pass = "";
            string sql = "";
            try
            {
                using ( var con = new SqlConnection(strCon.ConnectionString))
                {
                    con.Open();
                    string cashNum = GetNewCashAcc(con);

                    if (status == "COMPANY")
                    {
                        inn = num;
                        sql = CreateInsertSql(inn, pass, cashNum);
                    }
                    else
                    {
                        pass = num;
                        sql = CreateInsertSql(inn, pass, cashNum);
                    }
                    var command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception e) { MessageBox.Show(e.Message); }
        }


        /// <summary>
        /// Выводит счета клиента 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable PrintClientCash(string status, string num)
        {
            dtDataWin = new DataTable();

            using (var con = new SqlConnection(strCon.ConnectionString))
            {
                string sql = "";
                try
                {
                    if(status== "COMPANY")
                    {
                        sql = $"SELECT * FROM CashAccounts where NumClientINN = N'{num}'";
                    }
                    else { sql = $"SELECT * FROM CashAccounts where NumClientPassport = N'{num}'"; }
                    UpdateDt(con, sql);
                }
                catch (Exception e) { MessageBox.Show(e.Message); }
            }


            return dtDataWin;
        }

        /// <summary>
        /// Удаляет выбраный счет
        /// </summary>
        /// <param name="cashNum"></param>
        public void DeleteCashAcc(string cashNum)
        {
            using (var con  = new SqlConnection(strCon.ConnectionString))
            {
                try
                {
                    con.Open();
                    string sql = $"Delete CashAccounts where NumCashAcc = N'{cashNum}'";
                    var command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();

                }
                catch(Exception e) { MessageBox.Show(e.Message); }
            }
        }

        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="status"></param>
        /// <param name="num"></param>
        public void DelClient(string status, string num)
        {
            
            string sql = "";
            using (var con = new SqlConnection(strCon.ConnectionString))
            {
                con.Open();
                try
                {
                    if (status != "COMPANY")
                    {
                        
                        sql = SqlDelClient(num, "Client", "Passport");
                    }
                    else
                    {
                        sql = SqlDelClient(num, "Company", "INN");
                    }

                    var command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();

                }
                catch (Exception e) { MessageBox.Show(e.Message); }
            }
        }

        /// <summary>
        /// проверят есть ли в базе такой документ с таким номером
        /// </summary>
        /// <param name="num"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool CheckNumDoc(string num, string status)
        {
            bool flag = true;
            string sql = "";
            List<string> li = new List<string>();
            try
            {
                using (var con = new SqlConnection(strCon.ConnectionString))
                {
                    con.Open();
                    if (status != "COMPANY")
                    {
                        sql = $"SELECT Passport FROM dbo.Client where Passport = N'{num}'";
                    }
                    else
                    {
                        sql = $"SELECT Inn FROM dbo.Company where Inn = N'{num}'";
                    }
                    var command = new SqlCommand(sql, con);
                   var res = command.ExecuteReader();
                    int i = 0;//номер столбца
                    while (res.Read())
                    {
                      li.Add(res[i].ToString());
                        
                    }
                    if (li.Count == 0)
                    {
                        flag = false;
                    }
                }

                
            }
            catch(Exception e) { MessageBox.Show(e.Message); }

            return flag;
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Добавляеит нового клиента в базу
        /// </summary>
        /// <param name="cl"></param>
        public void AddClient(ClientOLD cl)
        {
            try
            {
                string sql = "";
                using(var con = new SqlConnection(strCon.ConnectionString))
                {
                    con.Open();
                    if (cl.Status == "COMPANY")
                    {
                        sql = $"INSERT dbo.Company(" +
                        "CompName," +
                        "CreateDay," +
                        "INN,Finance," +
                        "BankRating," +
                        "ClStatus," +
                        "Adress," +
                        "ActivLevel," +
                        "FirstTrans)" +

                       $"VALUES(N'{cl.FName}'," +
                        $"'{cl.BrDay.ToString("yyyy-MM-dd")}'," +
                        $"N'{cl.NumDoc}'," +
                        $"{cl.Finance.ToInt32()}," +
                        $"{cl.Rating.ToInt32()}," +
                        $"N'{cl.Status}'," +
                        $"N'{cl.Adress}'," +
                        $"{0}," +
                        $"N'{DateTime.Now.ToShortTimeString()}')";

                    }

                    else
                    {
                        sql = $"INSERT dbo.Client(FName, LName, BrthDay, Passport, Finance, BankRating, ClStatus, Adress, WorkPlace, ActivLevel, FrstTrans)" +
                            $"VALUES(N'{cl.FName}'," +
                            $"N'{cl.LName}', " +
                            $"'{cl.BrDay.ToString("yyyy-MM-dd")}', " +
                            $"N'{cl.NumDoc}', " +
                            $"{cl.Finance}, " +
                            $"{cl.Rating.ToInt32()}, " +
                            $"N'{cl.Status}'," +
                            $"N'{cl.Adress}'," +
                            $"N'{cl.WorkPlace}', " +
                            $"0," +
                            $"'{DateTime.Now.ToShortTimeString()}')";
                    }



                    var command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Add");

                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

        }


        /// <summary>
        /// Получаем клиента из базы данных
        /// </summary>
        /// <param name="status">Статус клиента</param>
        /// <param name="num">номер документа</param>
        /// <returns></returns>
        public ClientOLD GetClientFromDB(string status, string num)
        {
            ClientOLD cl = new ClientOLD();
            
            List<string> li = new List<string>();
            string sql = "";
            try
            {
               using(var con = new SqlConnection(strCon.ConnectionString))
                {
                    con.Open();
                    if(status == "COMPANY")
                    {
                        sql = $"SELECT * FROM dbo.Company WHERE INN =  N'{num}'";
                        var com = new SqlCommand(sql, con);
                        var res = com.ExecuteReader();
                        while (res.Read())
                        {
                            cl = new ClientOLD(res[cd.Inn].ToString(), ///string numDoc
                                            res[cd.CompStatus].ToString(), ///string status
                                            res[cd.CompName].ToString(),/// string fName
                                            res[cd.Compfinance].ToString(),///  string finance
                                            res[cd.CompAdress].ToString(), ///   string adress
                                            res[cd.CompRating].ToString(), ///   string rating
                                            Convert.ToDateTime(res[cd.CompCreateDate])); ///   DateTime brDay
                        }
                    }
                    else
                    {
                        sql = $"SELECT * FROM dbo.Client WHERE Passport =  N'{num}'";
                        var com = new SqlCommand(sql, con);
                        var res = com.ExecuteReader();
                        while (res.Read())
                        {
                            cl = new ClientOLD(res[cd.Passport].ToString(), /// string numDoc,
                                            res[cd.Status].ToString(),///string status,
                                            res[cd.Name].ToString(),///string fName, 
                                            res[cd.Lname].ToString(),///string lName,
                                            res[cd.Finance].ToString(),///string finance,
                                            res[cd.Adress].ToString(), ///string adress, 
                                            res[cd.Rating].ToString(),///string rating, 
                                            res[cd.WorkPlace].ToString(),///string workPlace,
                                          Convert.ToDateTime( res[cd.BrhDay])); ///DateTime brDay

                        
                        }
                    }

                    
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            return cl;
        }

        /// <summary>
        /// Изменяет данные клиента
        /// </summary>
        /// <param name="cl">Клиент с изменнёными данными</param>
        /// <param name="oldnum">номер документа до обновления</param>
        public void ChangeClient(ClientOLD cl, string oldnum)
        {
            try
            {
                string sql = "";
                using (var con = new SqlConnection(strCon.ConnectionString))
                {
                    con.Open();
                    cl.Finance.Replace(',', '.');

                    if (cl.Status == "COMPANY")
                    {
                        sql = $"UPDATE Company SET " +
                            $"CompName = N'{cl.FName}'," +
                           $" CreateDay = '{cl.BrDay.ToString("yyyy-MM-dd")}'," +
                           $" INN = '{cl.NumDoc}', " +
                           $" Finance = '{cl.Finance.Replace(',', '.')}', " +
                           $" BankRating = {cl.Rating}, " +
                           $"ClStatus = '{cl.Status}',  " +
                           $"Adress = N'{cl.Adress}' " +
                            $" WHERE INN = '{oldnum}'";
                    }
                    else
                    {
                        sql = $"UPDATE dbo.Client SET FName = N'{cl.FName}'," +
                           $" LName = N'{cl.LName}'," +
                           $" BrthDay = '{cl.BrDay.ToString("yyyy-MM-dd")}'," +
                           $" Passport = '{cl.NumDoc}', " +
                           $" Finance = '{cl.Finance.Replace(',', '.')}', " +
                           $" BankRating = {cl.Rating}, " +
                           $"ClStatus = '{cl.Status}',  " +
                           $"Adress = N'{cl.Adress}', " +
                           $"WorkPlace = N'{cl.WorkPlace}'" +
                           $" WHERE Passport = '{oldnum}'";
                    }

                    var command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Change");
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        /// <summary>
        /// Сохраняет в список все счета клиента
        /// </summary>
        /// <param name="numCl">клиент</param>
        /// <param name="status">статус</param>
        /// <returns></returns>
        public List<string> ClientCashAcc(string numCl, string status)
        {
            List<string> li = new List<string>();
            try
            {
                
                using (var con = new SqlConnection(strCon.ConnectionString))
                {
                    string cl = "";
                    if (status != "COMPANY")
                    {
                        cl = $"NumClientPassport = '{numCl}'";
                    }
                    else
                    {
                        cl = $"NumClientInn = '{numCl}'";

                    }
                    con.Open();
                    string sql = $"Select NumCashAcc from CashAccounts where {cl} ";
                    var command = new SqlCommand(sql, con);
                    var res = command.ExecuteReader();
                    while (res.Read())
                    {
                        li.Add(res["NumCashAcc"].ToString());
                    }
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            return li;
        }

        /// <summary>
        /// Отображает срадства на счету
        /// </summary>
        /// <param name="accNum">номер счета</param>
        /// <returns></returns>
        public string FinanceOnAcc(string accNum)
        {
            string fin = "";
            try
            {
                using(var con = new SqlConnection(strCon.ConnectionString))
                {
                    con.Open();
                    string sql = $"Select AccFinance from CashAccounts where NumCashAcc = N'{accNum}'";
                    var com = new SqlCommand(sql, con);
                    var res = com.ExecuteReader();
                    while (res.Read())
                    {
                        fin = res["AccFinance"].ToString();
                    }
                       
                }

            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            return fin;
        }

        /// <summary>
        /// Обновляет данные по счетам
        /// </summary>
        /// <param name="firstAcc"></param>
        /// <param name="firstCash"></param>
        /// <param name="secAcc"></param>
        /// <param name="secCash"></param>
        public void TransferClientsAcc(string firstAcc, string firstCash, string secAcc,  string secCash )
        {
            try
            {
                using (var con = new SqlConnection(strCon.ConnectionString))
                {
                    con.Open();

                    var com = new SqlCommand(UpdateFin(firstAcc, firstCash), con);
                    com.ExecuteNonQuery();
                    com = new SqlCommand(UpdateFin(secAcc, secCash), con);
                    com.ExecuteNonQuery();
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            MessageBox.Show("OK");
        }

        /// <summary>
        /// проверяет существует ли такой счет
        /// </summary>
        /// <param name="enterAcc"></param>
        /// <returns></returns>
        public bool NeedCashAcc(string enterAcc)
        {
            bool need = false;

            using (var con = new SqlConnection(strCon.ConnectionString))
            {
                string sql = $"SELECT NumCashAcc FROM CashAccounts WHERE NumCashAcc = '{enterAcc}'";

                con.Open();

                var command = new SqlCommand(sql, con);
                var res = command.ExecuteReader();
                string ls = "";
                while (res.Read())
                {
                    ls = (res["NumCashAcc"].ToString());
                }

                if (ls == enterAcc) { need = true; }
            }



            return need;
        }

        /// <summary>
        /// Выдает кредит
        /// </summary>
        /// <param name="status">статус клиента</param>
        /// <param name="num">номер документа клиента ИНН или паспорт</param>
        /// <param name="finance">Сумма средств на счете</param>
        public void GiveCredit(string status, string num, string finance)
        {
            GivesomeCash(status, num, finance, "CREDIT");
        }

        /// <summary>
        /// Открытие вклада
        /// </summary>
        /// <param name="status">статус клиента</param>
        /// <param name="num">номер пасспорта или инн</param>
        /// <param name="finance">Сумма вклада</param>
        public void GiveDeposite(string status, string num, string finance)
        {
            GivesomeCash(status, num, finance, "DEPOSITE");
        }

        /// <summary>
        /// Поиск клиента по номеру документа или имени
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="NumDoc"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable ReqestClientsFromNUM(string NameDB, string NumDoc, string type)
        {
            dtDataWin = new DataTable();

            using (var con = new SqlConnection(strCon.ConnectionString))
            {
                try
                {
                    string sql = $"SELECT * FROM {NameDB} where {type} = N'{NumDoc}' ";
                    UpdateDt(con, sql);
                }
                catch (Exception e) { MessageBox.Show(e.Message); }
            }


            return dtDataWin;
        }


       
        // catch(Exception e) { MessageBox.Show(e.Message); }


        #region HelperMetods

        /// <summary>
        /// Шаблон выдачи вклада или депозита
        /// </summary>
        /// <param name="status"></param>
        /// <param name="num"></param>
        /// <param name="finance"></param>
        private void GivesomeCash(string status, string num, string finance, string typeCashAcc)
        {
            string inn = "";
            string pass = "";
            string sql = "";
            
            try
            {
                using (var con = new SqlConnection(strCon.ConnectionString))
                {
                    con.Open();
                    string cashNum = GetNewCashAcc(con);

                    if (status == "COMPANY")
                    {
                        inn = num;
                        sql = SQLInsertALLCasAcc(typeCashAcc, finance, inn, pass, cashNum);
                    }
                    else
                    {
                        pass = num;
                        sql = SQLInsertALLCasAcc(typeCashAcc, finance, inn, pass, cashNum);
                    }
                    var command = new SqlCommand(sql, con);
                    command.ExecuteNonQuery();
                    MessageBox.Show("add");
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        /// <summary>
        /// создаёт Запрос SQL для удаления клиента
        /// </summary>
        /// <param name="num">номер паспорта </param>
        /// <param name="dataaBase">к какой БД обращаться</param>
        /// <param name="PasOrINN">паспорт или инн названия столбца по которому будет произходить удаление</param>
        /// <returns></returns>
        private static string SqlDelClient(string num, string dataaBase, string PasOrINN)
        {
            return $"delete  {dataaBase} where {PasOrINN} = N'{num}'";
        }

        /// <summary>
        /// создаёт Запрос SQL для добавления счета DEPOSITE
        /// </summary>
        /// <param name="inn"></param>
        /// <param name="pass"></param>
        /// <param name="cashNum"></param>
        /// <returns></returns>
        private static string CreateInsertSql(string inn, string pass, string cashNum)
        {
            return $"INSERT dbo.CashAccounts(NumCashAcc, NumClientPassport, NumClientINN, AccFinance, TypeAcc, PeriodAcc, Active)" +
                $"VALUES(N'{cashNum}', N'{pass}' , N'{inn}' ,0, N'DEPOSITE' ,N'{DateTime.Now.ToShortTimeString()}', 1) ";
        }

        /// <summary>
        /// создаёт Запрос SQL для добавления счета dctвсех типов
        /// </summary>
        /// <param name="typeCashAcc"></param>
        /// <param name="finance"></param>
        /// <param name="inn"></param>
        /// <param name="pass"></param>
        /// <param name="cashNum"></param>
        /// <returns></returns>
        private static string SQLInsertALLCasAcc(string typeCashAcc, string finance, string inn, string pass, string cashNum)
        {
            return $"INSERT dbo.CashAccounts(NumCashAcc, NumClientPassport, NumClientINN, AccFinance, TypeAcc, PeriodAcc, Active)" +
    $"VALUES(N'{cashNum}', N'{pass}' , N'{inn}' ,{finance}, N'{typeCashAcc}' ,N'{DateTime.Now.ToShortTimeString()}', 1) ";
        }

        /// <summary>
        ///  Метод генерирует новый счет
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private string GetNewCashAcc(SqlConnection con)
        {
            List<string> ls = new List<string>();
            var count = new SqlCommand(" SELECT  NumCashAcc from dbo.CashAccounts", con);
            var res = count.ExecuteReader();
            while (res.Read())
            {
                ls.Add(res["NumCashAcc"].ToString());
            }
            res.Close();



            string CAshNum = GetIDCash(ls);
            return CAshNum;

        }

        /// <summary>
        /// метод создаёт 16-ти значный счет и проверяет его в базе
        /// </summary>
        /// <param name="cash_Accounts">база счетов</param>
        /// <returns></returns>
        private string GetIDCash(List<string> cash_Accounts)
        {
            string a = "";
            while (a == "")
            {
                Random rnd = new Random();

                for (int i = 0; i < 16; i++)
                {
                    a += rnd.Next(0, 9).ToString();

                }

                foreach (var id in cash_Accounts)
                {
                    if (a == id)
                    {
                        a = "";
                    }
                }
            }

            return a;
        }

        /// <summary>
        /// SQL Запрос обновление счета по номеру счета
        /// </summary>
        /// <param name="firstAcc"></param>
        /// <param name="firstCash"></param>
        /// <returns></returns>
        private static string UpdateFin(string firstAcc, string firstCash)
        {
            return $"UPDATE dbo.CashAccounts SET AccFinance = '{firstCash}'  WHERE NumCashAcc = '{firstAcc}'";
        }

        
        #endregion
    }
}

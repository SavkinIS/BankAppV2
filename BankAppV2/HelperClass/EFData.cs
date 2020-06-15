using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankAppV2.HelperClass
{
    class EFData
    {

        SkillDBEntities sk;

        public EFData()
        {
            sk = new SkillDBEntities();
            
        }

        /// <summary>
        ///  Метод выводит все Компании из базы
        /// </summary>
        /// <returns></returns>
        public List<Company> PrintData()
        {
            return sk.Company.ToList();
        }

        /// <summary>
        ///  Мептод выводит всх Клиентов из базы
        /// </summary>
        /// <returns></returns>
        public List<Client> PrintDataClient()
        {
            return sk.Client.ToList();
        }

        internal void NewCashAcc(object status, object numPassOrInn)
        {
            throw new NotImplementedException();
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
            CashAccounts ca = new CashAccounts()
            {
                AccFinance = 0,
                Active = true,
                NumCashAcc = GetNewCashAcc(),
                PeriodAcc = DateTime.Now.AddYears(5),
                TypeAcc = "DEPOSITE"
            };
            try
            {
                    if (status == "COMPANY")
                    {
                        inn = num;
                        ca.NumClientINN = num;
                        sk.CashAccounts.Local.Add(ca);
                    }
                    else
                    {
                        pass = num;
                        ca.NumClientPassport = num;
                        sk.CashAccounts.Local.Add(ca);
                     }

                sk.SaveChanges();
             }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        /// <summary>
        /// Выводит счета клиента 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<CashAccounts> PrintClientCash(string status, string num)
        {
            try
                {
                    if (status == "COMPANY")
                    {
                    return sk.CashAccounts.Where(a => (a.NumClientINN == num)).ToList();
                    }
                    else 
                    {
                    return sk.CashAccounts.Where(a => (a.NumClientPassport == num)).ToList();
                    }
                   
                }
                catch (Exception e) { MessageBox.Show(e.Message); return new List<CashAccounts>(); }
        }

        /// <summary>
        /// Удаляет выбраный счет
        /// </summary>
        /// <param name="cashNum"></param>
        public void DeleteCashAcc(string cashNum)
        {
            try
                {
                var ca = sk.CashAccounts.Where(a => (a.NumCashAcc == cashNum)).FirstOrDefault();
                sk.CashAccounts.Remove(ca);
                sk.SaveChanges();
                }
                catch (Exception e) { MessageBox.Show(e.Message); }            
        }

        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="status"></param>
        /// <param name="num"></param>
        public void DelClient(string status, string num)
        {
                try
                {
                    if (status == "COMPANY")
                    {
                    var co = sk.Company.Where(c => (c.INN == num)).FirstOrDefault();
                    sk.Company.Remove(co);
                    }
                    else
                    {
                    var cl = sk.Client.Where(c => (c.Passport == num)).FirstOrDefault();
                    sk.Client.Local.Remove(cl);
                    }

                    sk.SaveChanges();
                }
                catch (Exception e) { MessageBox.Show(e.Message); }
            
        }

        /// <summary>
        /// проверят есть ли в базе документ с таким номером
        /// </summary>
        /// <param name="num"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool CheckNumDoc(string num, string status)
        {
            bool flag = false;
           
            try
            {
                if (status == "COMPANY")
                {
                    var doc = sk.Company.Where(c => (c.INN == num)).ToList();
                    foreach (var d in doc)
                    {
                        if (d.INN == num) { flag = true; }
                    }
                }
                else
                {
                    var doc = sk.Client.Where(c => (c.Passport == num)).ToList();
                    
                    if (doc.FirstOrDefault(d => (d.Passport == num)) == null) { flag = true; }
                    
                }
                 
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

            return flag;
        }


        /// <summary>
        /// Добавляеит нового клиента в базу
        /// </summary>
        /// <param name="cl"></param>
        public void AddClient(Client cl)
        {
            try
            {
                cl.FrstTrans  = TimeSpan.FromMinutes(12.00);
                cl.ActivLevel = 0;
                
                sk.Client.Local.Add(cl);
               var i = sk.SaveChanges();
              
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        /// <summary>
        /// Добавляеит нового клиента Компанию в базу
        /// </summary>
        /// <param name="cl"></param>
        public void AddCompany(Company cl)
        {
            try
            {
                cl.FirstTrans = TimeSpan.FromMinutes(12.00);
                cl.ActivLevel = 0;
                sk.Company.Local.Add(cl);
                sk.SaveChanges();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        /// <summary>
        /// Получаем клиента из базы данных
        /// </summary>
        /// <param name="status">Статус клиента</param>
        /// <param name="num">номер документа</param>
        /// <returns></returns>
        public Client GetClientFromDB(string num)
        {
            Client cl = new Client();                   
            try
            {
                cl = sk.Client.Where(c => (c.Passport == num)).FirstOrDefault();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            return cl;
        }

        /// <summary>
        /// Получаем Компанию из базы данных
        /// </summary>
        /// <param name="status">Статус клиента</param>
        /// <param name="num">номер документа</param>
        /// <returns></returns>
        public Company GetCompanyFromDB(string num)
        {
            Company cl = new Company();
            try
            {
                cl = sk.Company.Where(c => (c.INN == num)).FirstOrDefault();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            return cl;
        }

       

        /// <summary>
        /// Изменяет данные клиента
        /// </summary>
        /// <param name="cl">Клиент с изменнёными данными</param>
        /// <param name="oldnum">номер документа до обновления</param>
        public void ChangeClient(Client cl, string oldnum)
        {
            try
            {
              var ocl = sk.Client.Where(c => (c.Passport == oldnum)).FirstOrDefault();
                ocl.ClStatus = cl.ClStatus;
                ocl.Adress = cl.Adress;
                ocl.ActivLevel = cl.ActivLevel;
                ocl.BankRating = cl.BankRating;
                ocl.BrthDay = cl.BrthDay;
                ocl.Finance = cl.Finance;
                ocl.FName = cl.FName;
                ocl.LName = cl.LName;
                ocl.Passport = cl.Passport;
                ocl.WorkPlace = cl.WorkPlace;
               
                sk.SaveChanges();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        /// <summary>
        /// Изменяет данные компании
        /// </summary>
        /// <param name="cl">Клиент с изменнёными данными</param>
        /// <param name="oldnum">номер документа до обновления</param>
        public void ChangeCompany(Company cl, string oldnum)
        {
            try
            {
                var ocl = sk.Company.Where(c => (c.INN == oldnum)).FirstOrDefault();
                ocl.ClStatus = cl.ClStatus;
                ocl.Adress = cl.Adress;
                ocl.ActivLevel = cl.ActivLevel;
                ocl.BankRating = cl.BankRating;
                ocl.CreateDay = cl.CreateDay;
                ocl.Finance = cl.Finance;
                ocl.CompName = cl.CompName;
                
                ocl.INN= cl.INN;
                
                sk.SaveChanges();
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
                    
                    if (status == "COMPANY")
                    {
                    li = sk.CashAccounts.Where(ca => (ca.NumClientINN == numCl))
                                        .Select(c => c.NumCashAcc.ToString())
                                        .ToList();
                    }
                    else
                    {
                    li = sk.CashAccounts.Where(ca => (ca.NumClientPassport == numCl))
                                    .Select(c => c.NumCashAcc.ToString())
                                    .ToList();

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
                fin = sk.CashAccounts.Where(ca => (ca.NumCashAcc == accNum))
                                    .FirstOrDefault()
                                    .AccFinance.ToString();
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
        public void TransferClientsAcc(string firstAcc, string firstCash, string secAcc, string secCash)
        {
            try
            {
                var finF = sk.CashAccounts.Where(ca => (ca.NumCashAcc == firstAcc))
                                     .FirstOrDefault()
                                     .AccFinance = Convert.ToDecimal(firstCash);
              

                 sk.CashAccounts.Where(ca => (ca.NumCashAcc == secAcc))
                                     .FirstOrDefault()
                                     .AccFinance = Convert.ToDecimal(secCash);
                //finS = Convert.ToDecimal(secCash);

                sk.SaveChanges();
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
            try
            {
                string ls = sk.CashAccounts.Where(ca => (ca.NumCashAcc==enterAcc)).FirstOrDefault().NumCashAcc;

                if (ls == enterAcc) { need = true; }
            }
            catch(Exception e) { MessageBox.Show(e.Message); }
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
            MessageBox.Show("Кредит Выдан");
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
        public List<Client> ReqestClientsFromNUM( string NumDoc, string type )
        {
            if(type == "Passport")
            {
                return sk.Client.Where(c => (c.Passport == NumDoc)).ToList();
            }
            else
            {
                return sk.Client.Where(c => (c.LName == NumDoc)).ToList();
            }            
        }

        /// <summary>
        /// Поиск Company по номеру документа или имени
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="NumDoc"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Company> ReqestCompanyFromNUM( string NumDoc, string type)
        {
            if (type == "INN")
            {
                
                return sk.Company.Where(c => (c.INN == NumDoc)).ToList();
            }
            else
            {
                return sk.Company.Where(c => (c.CompName == NumDoc)).ToList();
            }
        }

        /// <summary>
        /// Поиск Company по номеру документа или имени
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="NumDoc"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<CashAccounts> ReqestCashAccountsFromNUM(string NumDoc)
        {
             return sk.CashAccounts.Where(c => (c.NumCashAcc == NumDoc)).ToList();
            
        }


        public async Task<List<CashAccounts>> ReqCashAsync(string NumDoc)
        {
          return  await Task.Run(() => ReqestCashAccountsFromNUM(NumDoc));
        }

        public async Task<List<Company>> ReqCompAsync(string NumDoc, string type)
        {
            return await Task.Run(() => ReqestCompanyFromNUM(NumDoc, type));
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region HelperMetods

        /// <summary>
        /// Шаблон выдачи вклада или депозита или кредита
        /// </summary>
        /// <param name="status"></param>
        /// <param name="num"></param>
        /// <param name="finance"></param>
        private void GivesomeCash(string status, string num, string finance, string typeCashAcc)
        {
            string inn = "";
            string pass = "";
           
            try
            {               
                    string cashNum = GetNewCashAcc();

                    if (status == "COMPANY")
                    {
                        inn = num;
                       
                        sk.CashAccounts.Add(new CashAccounts
                         {
                                AccFinance = Convert.ToDecimal(finance),
                                NumClientINN = inn,
                                Active = true,
                                NumCashAcc = cashNum,
                                TypeAcc = typeCashAcc,
                                PeriodAcc = DateTime.Now.AddYears(5)
                        });
                    }
                    else
                    {
                        pass = num;
                         sk.CashAccounts.Add(new CashAccounts
                         {
                                AccFinance = Convert.ToDecimal(finance),
                                NumClientPassport = pass,
                                Active = true,
                                NumCashAcc = cashNum,
                                TypeAcc = typeCashAcc,
                                PeriodAcc = DateTime.Now.AddYears(5)
                          }); 
                    }
                sk.SaveChanges();
                MessageBox.Show("add");
               
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            
        }

        /// <summary>
        ///  Метод генерирует новый счет
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private string GetNewCashAcc()
        {
            var ls = sk.CashAccounts.ToList().Select(c=> c.NumCashAcc.ToString()).ToList<string>(); ;
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

        
        #endregion


    }
}

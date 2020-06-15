using BankAppV2.HelperClass;
using BankAppV2.View;
using BankAppV2.Windows;
using MyExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankAppV2.Model
{
    class ModelDepos
    {
        double procents = 12;
        EFData my;
        bool flag = false;

        public ModelDepos()
        {
            my = new EFData();
        }

        /// <summary>
        ///  открыть вклад
        /// </summary>
        /// <param name="numCl">номер документа клиента</param>
        /// <param name="status">Статус клиента </param>
        internal void Open(string numCl, string status, IViewDeposite view)
        {
            Conculate(view);
            if (flag)
            {
                my.GiveDeposite(status, numCl, view.SumDep);
                foreach (Window window in App.Current.Windows)
                {
                    if (window is DepositeWin)
                        window.Close();
                }
            }
        }

        /// <summary>
        /// расчитать Вклад
        /// </summary>
        internal void Conculate(IViewDeposite view)
        {
            try
            {
                double proc = procents - view.Rating.ToDouble();
                view.Procents = proc.ToString();
                if (view.TypeDep == "Ежемесячная капитализация" && view.SumDep != "" && view.MonthsDep != "")
                {

                    double beginsum = Convert.ToDouble(view.SumDep);
                    int month = Convert.ToInt32(view.MonthsDep);
                    if (month > 60) { throw new Exception("Максимальный срок вклада 60 месяцев"); }

                    if (beginsum < 0 || month < 0)
                    {
                        throw new Exception("Вводимые значения должны быть положительные!");
                    }
                    for (int m = 0; m < month; m++)
                    {
                        beginsum += ((beginsum / 100) * proc / 10);
                    }
                    view.FinanceEnd = beginsum.ToString("f2");
                    flag = true;

                }
                else if (view.SumDep != "" && view.MonthsDep != "")
                {
                    double beginsum = Convert.ToDouble(view.SumDep);
                    int month = Convert.ToInt32(view.MonthsDep);
                    if (month > 60) { throw new Exception("Максимальный срок вклада 60 месяцев"); }
                    if (beginsum < 0 || month < 0)
                    {
                        throw new Exception("Вводимые значения должны быть положительные!");
                    }

                    beginsum += ((beginsum / 100) * procents);

                    view.FinanceEnd = beginsum.ToString("f2");
                    flag = true;

                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Загрузка даных 
        /// </summary>
        /// <param name="numCl"></param>
        /// <param name="status"></param>
        internal void Loader(string numCl, string status, IViewDeposite view)
        {
            if (status != "COMPANY") view.Rating = my.GetClientFromDB(numCl).BankRating.ToString();
            else view.Rating = my.GetCompanyFromDB(numCl).BankRating.ToString();
        }


    }
}

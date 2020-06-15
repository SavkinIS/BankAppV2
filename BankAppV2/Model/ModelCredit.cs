using BankAppV2.HelperClass;
using BankAppV2.View;
using MyExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankAppV2.Model
{
    class ModelCredit
    {
        EFData my;
        /// <summary>
        /// Стандартная ставка для всех
        /// </summary>
        double procents = 16;
        bool flag = false;

        public ModelCredit()
        {
            my = new EFData();
        }

        /// <summary>
        /// Заполненеие при загрузке
        /// </summary>
        /// <param name="num"></param>
        /// <param name="status"></param>
        public void Loader(string num, string status, IViewCredit view)
        {
            if (status != "COMPANY") view.Rating = my.GetClientFromDB(num).BankRating.ToString();
            else view.Rating = my.GetCompanyFromDB(num).BankRating.ToString();

        }

        /// <summary>
        /// Ввалидация ввода на цифры
        /// </summary>
        internal void Validation(KeyEventArgs e, object s)
        {
            Validators.Validinput(e, s);
        }

        /// <summary>
        /// Выдача кредита
        /// </summary>
        /// <param name="num"></param>
        /// <param name="status"></param>
        internal void Give(string num, string status, IViewCredit view)
        {
            Calculate(view);
            if (flag) { my.GiveCredit(status, num, view.SumCredit); }
        }

        /// <summary>
        /// Расчитывает кредит
        /// </summary>
        internal void Calculate(IViewCredit view)
        {
            try
            {
                double proc = procents - view.Rating.ToDouble();
                view.EndProcent = "Итоговый процент " + proc.ToString();
                if (view.SumCredit.ToDouble() > 0 && view.Months.ToDouble() > 0) { }
                else { throw new Exception("Проверьте коректность вводимых данных. Сумма и срок должны быть положительные!!"); }
                if (view.SumCredit != "" && view.Months != "")
                {
                    double sumCRD = 0;
                    double sum = view.SumCredit.ToDouble();

                    double period = view.Months.ToDouble();
                    if (period > 60) { throw new Exception("Максимальный срок кредита 60 месяцев"); }
                    double years = (period / 12);


                    double monthProc = (proc / 12.0) / 100;


                    double kofAut = (monthProc * Math.Pow(1 + monthProc, period)) / (Math.Pow(1 + monthProc, period) - 1);
                    sumCRD = sum * kofAut;

                    view.PayFormonth = "Ежемесячный платёж " + (sumCRD.ToString("f2"));

                    flag = true;
                }

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
    }
}

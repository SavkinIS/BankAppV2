using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExtention
{
    public static class SumAndSub
    {

        /// <summary>
        /// Складывает два типа в Double
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string SumDouble<T, T1>(this T a, T1 b)
        {
            try
            {

                var c = (Convert.ToDouble(a) + Convert.ToDouble(b));
                return c.ToString();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return "";
            }
        }

        /// <summary>
        /// Вычитает два типа в Double и возвращает string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string SubDouble<T, T1>(this T a, T1 b)
        {
            try
            {

                var c = (Convert.ToDouble(a) - Convert.ToDouble(b));
                return c.ToString();
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message);
                return "";
            }
        }

        /// <summary>
        /// Переводит тип в INT32. Если не олучается возвращает 0;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int ToInt32<T>(this T a)
        {
            try
            {
                return Convert.ToInt32(a);
            }
            catch { return 0; }
        }

        /// <summary>
        /// Переводит тип в Double. Если не олучается возвращает 0;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Double ToDouble<T>(this T a)
        {
            try
            {
                return Convert.ToDouble(a);
            }
            catch { return 0; }
        }


    }
}

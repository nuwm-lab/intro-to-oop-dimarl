using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;

namespace ConsoleApplication1
{ 
    public class tringle
    {
        public int APointX, BPointX, CPointX, APointY, BPointY, CPointY;
        public double AB, BC, CA;

        public tringle()
        {
            setTringlePoint();
            TSquare();

            Console.WriteLine("Площа заданого трикутника = "+TSquare());
        }

        private void setTringlePoint()
        {
            try 
            {
                Console.WriteLine("Введіть координату Х точки А");
                APointX = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введіть координату Y точки А");
                APointY = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введіть координату Х точки B");
                BPointX = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введіть координату Y точки B");
                BPointY = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введіть координату Х точки C");
                CPointX = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введіть координату Y точки C");
                CPointY = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Ви ввели не вірне значення");
                Console.ReadKey();
                Environment.Exit(0);
            }
            
        }

        private double TSquare()
        {
            AB = Math.Sqrt(Math.Pow((APointX - BPointX), 2) + Math.Pow((APointY - BPointY), 2));
            BC = Math.Sqrt(Math.Pow((BPointX - CPointX), 2) + Math.Pow((BPointY - CPointY), 2));
            CA = Math.Sqrt(Math.Pow((CPointX - APointX), 2) + Math.Pow((CPointY - APointY), 2));

            double p;
            p = (AB + BC + CA) / 2;

            return Math.Sqrt(p * (p - AB) * (p - BC) * (p - CA));
        }

    }

    class lab2
    {
        static void Main()
        {
            tringle object1 = new tringle();
       
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
//Створити об’єкт класу „трикутник на площині”, який заданий координатами своїх вершин. Визначити за допомогою методу класу його, площу.

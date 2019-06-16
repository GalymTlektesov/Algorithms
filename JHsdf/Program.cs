using System;
using System.Threading;

namespace Algorithms
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /* for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }*/

            DrawPiramid(5);//Рисуем пирамиду

            int[] array = { 2, 4, 5, 6, 3 };
            Console.WriteLine(Summ(array, 1));
            Console.WriteLine(BigArray(array, 0));

        }


        public static void DrawPiramid(int a)//Входим в функцию
        {
            for (int i = 1; i <= a; i++)//цикл i от 1 до 5
            {
                for (int j = i; j <= a; j++)//внутрений цикл j от i до 5 // Первое значение от 1 до 5, второе 2 до 5, от 3 до 5, от 4 до 5, 5 до 5
                {
                    Console.Write("  ");//внутри цикла j два пробела
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*" + " ");
                }
                Console.WriteLine();
            }
        }

        /*
         *          *
         *        * * *
         *      * * * * *
         *    * * * * * * *
         *  * * * * * * * * *
         */



        public static int Summ(int[] array, int i)
        {
            if (i < array.Length)
            {
                return array[i] + Summ(array, i + 1);
            }
            return array[0];
        }

        public static int BigArray(int[] array, int i)
        {
            if (i < array.Length)
            {
                if(array[0] < array[i])
                array[0] = array[i];
                return BigArray(array, i + 1);
            }
            return array[0];
        }
    }
}

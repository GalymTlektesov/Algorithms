using System;
using System.Collections.Generic;
using System.Threading;
using JHsdf.DataStructures;

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
            List<int> array = new List<int>{ 2, 4, 5, 6, 3, 1, 9, 3, 8 };
            //Console.WriteLine(Summ(array, 1));
            //Console.WriteLine(BigArray(array, 0));
            //Console.WriteLine(Fact(7));


            //PyramidDraw(7);

            //BiSearh(1000);

            for (int i = 0; i < array.Count; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();

            //BubbleSort(array);
            //CocktailSort(array);
            //ShellSort(array);
            var tree = new Tree<int>(array);
            array = tree.Inorder();

            for (int i = 0; i < array.Count; i++)
            {
                Console.Write($"{array[i]} ");
            }

        }


        /// <summary>
        /// Сотрировка пузырьком
        /// </summary>
        /// <param name="array"></param>
        public static void BubbleSort(int[] array)
        {
            for (int j = 0; j < array.Length; j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        var temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
        }


        /// <summary>
        /// Шейкерная сортировка
        /// </summary>
        /// <param name="array"></param>
        public static void CocktailSort(int[] array)
        {
            int Left = 0;
            int Right = array.Length - 1;

            while(Left < Right)
            {
                for(int i = Left; i < Right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        var temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
                Right--;
                for(int i = Right; i > Left; i--)
                {
                    if(array[i] < array[i - 1])
                    {
                        var temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                    }
                }
                Left++;
            }
        }


        /// <summary>
        /// Сортировка вставками
        /// </summary>
        /// <param name="array"></param>
        public static void InsertSort(int[] array)
        {
            for (int i = 3; i < array.Length; i++)
            {
                var temp = array[i];
                var j = i;
                while((j > 0) && (temp < array[j - 1]))
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = temp;
            }
        }

        /// <summary>
        /// Сортировка Шелла
        /// </summary>
        /// <param name="array"></param>
        public static void ShellSort(int[] array)
        {
            int step = array.Length / 2;
            while (step > 0)
            {
                for (int i = step; i < array.Length; i++)
                {
                    var j = i;
                    while (j >= step && array[j - step] > array[j]) 
                    {
                        var temp = array[j];
                        array[j] = array[j - step];
                        array[j - step] = temp;
                        j -= step;
                    }
                }
                step /= 2;
            }

        }



        public static void SpeedSort(int[] array, int support)//3
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < support)
                {
                    int j = i;
                    while(j < 0 && array[i] < support)
                    {
                        var temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                        support--;
                        j++;
                    }
                }
                if (array[i] > support)
                {
                    int j = i;
                    while(j < array.Length - 1 && array[i] > support)
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        support++;
                        j--;
                    }
                }
            }
        }


        public static void BiSearh(int isLong)
        {
            Console.WriteLine("Это игра, в котрой компьютер попробует отгадать задуманное вами число");
            Console.WriteLine($"Вам нужно загадать число от 1 до {isLong}");
            Console.WriteLine("если число которое задает компьютер больше вашего то нажмите - 0");
            Console.WriteLine("если число которое задает компьютер меньше вашего то нажмите - 1");
            Console.WriteLine("если число которое задает компьютер равен вашему то нажмите - 2");
            int a = 0;
            int isShort = 0;
            while (a != 2)
            {
                int[] array = new int[isLong + 1];
                for (int i = isShort; i <= isLong; i++)
                {
                    array[i] = i;
                    Console.Write($"{array[i]} ");
                }
                int left = isShort;
                int right = isLong;
                while (left < right)
                {
                    right--;
                    left++;
                }
                Console.WriteLine();
                Console.WriteLine(left);

                a = int.Parse(Console.ReadLine());
                if (a == 0)
                {
                    isLong = left - 1;
                }
                if(a == 1)
                {
                    isShort = left + 1;
                }
            }
            Console.WriteLine("Ура у меня получилось!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            PyramidDraw(7, "! ");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }



        public static void PyramidDraw(int a, string symbol)
        {
            for (int i = a; i > 0; i--)
            {
                for (int k = i; k < a; k++)
                {
                    Console.Write("  ");
                }
                for (int j = 0; j < i * 2 - 1; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < a; i++)
            {
                for (int k = i; k < a; k++)
                {
                    Console.Write("  ");
                }
                for (int j = 0; j < i * 2 - 1; j++)
                {
                    Console.Write(symbol);
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


        /// <summary>
        /// Суммирование значений нашего массива 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int Summ(int[] array, int i)
        {
            if (i < array.Length)
            {
                return array[i] + Summ(array, i + 1);
            }
            return array[0];
        }

        /// <summary>
        /// Ищем самый большой элемент массива
        /// </summary>
        /// <param name="array"></param>
        /// <param name="i"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Факториал
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int Fact(int a)
        {
            if(a != 1)
            {
                return a * Fact(a - 1);
            }
            return a;
        }


        public static int Speed(int a, int opr)
        {
            int[] array = new int[a];
            if(array.Length < 2)
            {
                return array[a];
            }
            return Speed(a - 1, 2);
        }
    }
}

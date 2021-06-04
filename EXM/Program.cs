using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace EXM
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> mass = new List<double>()
        {
            1,
            2,
            3,
            6,
            7,
            13,
            21
        };
            Analysis analysis = new Analysis(mass);

            analysis.task1.Join();
            analysis.task2.Join();


            var task3 = new Thread(analysis.Show_Res);
            task3.Start();
            task3.Join();

            Console.ReadKey();
        }

    }
    public class Analysis
    {
        List<double> mass;
        public Thread task1;
        public Thread task2;

        public Analysis(List<double> mass)
        {
            this.mass = mass;
            task1 = new Thread(Fibonachi);
            task2 = new Thread(Prime_Numbers);
            task1.Start();
            task2.Start();
        }
        public void Show_Res()
        {
            using (StreamReader read1 = new StreamReader("Fibonachi.txt"))
            {
                string line = "";
                Console.WriteLine("Найденны числа фибоначи");
                while ((line = read1.ReadLine()) != null)
                {
                    Console.WriteLine(line);

                }
            }

            using (StreamReader read2 = new StreamReader("Prime_Numbers.txt"))
            {
                string line = "";
                Console.WriteLine("Найдены простые числа");
                while ((line = read2.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public void Fibonachi()
        {
            using (StreamWriter str1 = new StreamWriter("Fibonachi.txt"))
            {
                for (var i = 2; i < mass.Count; i++)
                {
                    if (mass[i - 2] + mass[i - 1] == mass[i])
                    {
                        str1.WriteLine(mass[i]);
                    }
                }
            }
        }
        public void Prime_Numbers()
        {
            using (StreamWriter str = new StreamWriter("Prime_Numbers.txt"))
            {
                bool prost;
                for (var i = 0; i < mass.Count; i++)
                {
                    prost = true;
                    for (int j = 2; j <= mass[i] / 2; j++)
                    {
                        if (mass[i] % j == 0)
                        {
                            prost = false;
                            break;
                        }
                    }
                    if (prost)
                    {
                        str.WriteLine(mass[i]);
                    }
                }
            }
        }
    }
}

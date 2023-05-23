using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ipp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum1 = 0, sum2 = 0, sum3 = 0;
            long elapsedTime1 = 0, elapsedTime2 = 0, elapsedTime3 = 0;

            Stopwatch stopwatch = new Stopwatch();

            // Потік 1: Обчислення суми цілих чисел від 1 до 10 000
            Thread thread1 = new Thread(() =>
            {
                stopwatch.Start();
                for (int i = 1; i <= 10000; i++)
                {
                    sum1 += i;
                }
                stopwatch.Stop();
                elapsedTime1 = stopwatch.ElapsedMilliseconds;
            });

            // Потік 2: Обчислення суми парних чисел від 1 000 до 20 000
            Thread thread2 = new Thread(() =>
            {
                stopwatch.Start();
                for (int i = 1000; i <= 20000; i += 2)
                {
                    sum2 += i;
                }
                stopwatch.Stop();
                elapsedTime2 = stopwatch.ElapsedMilliseconds;
            });

            // Потік 3: Обчислення суми непарних чисел від 3 000 до 21 000
            Thread thread3 = new Thread(() =>
            {
                stopwatch.Start();
                for (int i = 3000; i <= 21000; i += 2)
                {
                    sum3 += i;
                }
                stopwatch.Stop();
                elapsedTime3 = stopwatch.ElapsedMilliseconds;
            });

            // Запуск потоків
            thread1.Start();
            thread2.Start();
            thread3.Start();

            // Очікування завершення потоків
            thread1.Join();
            thread2.Join();
            thread3.Join();
             
            // Виведення результатів
            Console.WriteLine($"Task1 completed in {elapsedTime1} ms with sum = {sum1}");
            Console.WriteLine($"Task2 completed in {elapsedTime2} ms with sum = {sum2}");
            Console.WriteLine($"Task3 completed in {elapsedTime3} ms with sum = {sum3}");

            // Зміна пріоритетів потоків


            // Потік 1: Обчислення суми цілих чисел від 1 до 10 000
            Thread thread11 = new Thread(() =>
            {
                stopwatch.Start();
                for (int i = 1; i <= 10000; i++)
                {
                    sum1 += i;
                }
                stopwatch.Stop();
                elapsedTime1 = stopwatch.ElapsedMilliseconds;
            });

            // Потік 2: Обчислення суми парних чисел від 1 000 до 20 000
            Thread thread22 = new Thread(() =>
            {
                stopwatch.Start();
                for (int i = 1000; i <= 20000; i += 2)
                {
                    sum2 += i;
                }
                stopwatch.Stop();
                elapsedTime2 = stopwatch.ElapsedMilliseconds;
            });

            // Потік 3: Обчислення суми непарних чисел від 3 000 до 21 000
            Thread thread33 = new Thread(() =>
            {
                stopwatch.Start();
                for (int i = 3000; i <= 21000; i += 2)
                {
                    sum3 += i;
                }
                stopwatch.Stop();
                elapsedTime3 = stopwatch.ElapsedMilliseconds;
            });



            long totalTime = elapsedTime1 + elapsedTime2 + elapsedTime3;
            Console.WriteLine($"Total elapsed time: {totalTime} ms");



            ThreadPriority minPriority = ThreadPriority.Lowest;
            if (elapsedTime1 < elapsedTime2 && elapsedTime1 < elapsedTime3)
            {
                thread11.Priority = ThreadPriority.Highest;
            }
            else if (elapsedTime2 < elapsedTime1 && elapsedTime2 < elapsedTime3)
            {
                thread22.Priority = ThreadPriority.Highest;
            }
            else
            {
                thread33.Priority = ThreadPriority.Highest;
            }

            // Повторний розрахунок з новими пріоритетами
            sum1 = 0; sum2 = 0; sum3 = 0;
            stopwatch.Reset();

            thread11.Start();
            thread22.Start();
            thread33.Start();

            thread11.Join();
            thread22.Join();
            thread33.Join();

            Console.WriteLine($"Task1 completed in {elapsedTime1} ms with sum = {sum1}");
            Console.WriteLine($"Task2 completed in {elapsedTime2} ms with sum = {sum2}");
            Console.WriteLine($"Task3 completed in {elapsedTime3} ms with sum = {sum3}");

            totalTime = elapsedTime1 + elapsedTime2 + elapsedTime3;

            Console.WriteLine($"Total elapsed time: {totalTime} ms");

            Console.ReadLine();
        }
    }
}
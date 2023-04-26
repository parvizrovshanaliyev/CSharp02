using System;
using System.Threading;

namespace AsyncConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main thread starting");

            var worker = new Worker("child 1");
            Thread newThread = new Thread(worker.Run);
            newThread.Start();
            do
            {
                Console.Write(".");
                Thread.Sleep(100);

            } while (worker.Count != 10);
            Console.WriteLine("main thread terminating");
            Console.ReadLine();

        }
    }

    public class Worker
    {
        public int Count { get; set; }
        public Thread Thread { get; set; }

        public Worker(string name)
        {
            Count = 0;
            Thread = new Thread(this.Run)
            {
                Name = name
            };
            Thread.Start();
        }

        public void Run()
        {
            Console.WriteLine($"{this.Thread.Name} starting");
            do
            {
                Thread.Sleep(500);
                Console.WriteLine($"In {this.Thread.Name}, Count is {this.Count}");
                this.Count++;
            } while (this.Count <=10);

            Console.WriteLine($"{this.Thread.Name} terminating");
        }
    }
}

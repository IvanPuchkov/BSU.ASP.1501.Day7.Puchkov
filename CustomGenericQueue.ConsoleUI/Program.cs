using System;
using System.Collections.Generic;

namespace CustomGenericQueue.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomGenericQueue<int> queue=new CustomGenericQueue<int>(5);
            queue.EnQueue(1);
            queue.EnQueue(2);
            queue.EnQueue(3);
            queue.EnQueue(4);
            queue.EnQueue(5);
            Console.WriteLine($"Peek: {queue.Peek().ToString()}");
            Console.WriteLine($"Dequeue {queue.DeQueue()}");
            CustomGenericQueue<int>.CustomQueueIterator iterator = queue.Iterator;
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current);
            }
            Console.ReadKey();
        }
    }
}

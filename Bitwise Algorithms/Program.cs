using System;
using Bitwise_Algorithms;

    class Program
    {
        static void Main()
        {
            int number = 10;
            string binary = IntToBinary.ConvertToBinary(number);
            Console.WriteLine($"Binary format of {number} is {binary}\n-------------------------------------------\n");

        
            int setBitsCount = CountDigit.CountSetBits(number);
            Console.WriteLine($"Number of set bits in {number} is {setBitsCount}\n-------------------------------------------\n");


            int bit1 = 1; 
            int bit2 = 3;

            int result = SwapBit.SwapBits(number, bit1, bit2);
            Console.WriteLine($"Original number: {number} (binary: {Convert.ToString(number, 2)})");
            Console.WriteLine($"After swapping bits at positions {bit1} and {bit2}: {result} (binary: {IntToBinary.ConvertToBinary(result)})\n-------------------------------------------\n");


              int[] arr = {1, 2,3, 4, 7, 9, 2, 4 }; 
        BitwiseXor.FindTwoNonRepeatingElements(arr);

        Console.WriteLine("\n-------------------------------------------\n");

        var queue = new ThreadSafeQueue<int>();


        Thread producer = new Thread(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine($"Enqueued: {i}");
                Thread.Sleep(100); 
            }
        });


        Thread consumer = new Thread(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                if (queue.TryDequeue(out int item))
                {
                    Console.WriteLine($"Dequeued: {item}");
                }
                else
                {
                    Console.WriteLine("Queue was empty");
                }
                Thread.Sleep(150); 
            }
        });

        producer.Start();
        consumer.Start();

        producer.Join();
        consumer.Join();

    }

}

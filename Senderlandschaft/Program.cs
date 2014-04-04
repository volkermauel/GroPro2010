using System;

namespace Senderlandschaft
{
    class Program
    {
        static void Main()
        {
            var s = new Senderlandschaft();
            s.Add(new Sender(30f, 110f, 12.5f));
            s.Add(new Sender(65f, 100.3f, 27f));
            s.Add(new Sender(34.2f, 60f, 31.9f));
            s.Add(new Sender(114f, 100f, 18f));
            s.Add(new Sender(87.43f, 72.57f, 12.5f));
            s.Add(new Sender(94f, 120f, 12.5f));
            s.Add(new Sender(78.28f, 42.168f, 22.119f));
            s.Add(new Sender(118f, 60f, 28.5f));
            s.Add(new Sender(145f, 38f, 22.12f));
            s.Add(new Sender(125f, 122f, 22.12f));
            s.Add(new Sender(140f, 82f, 17f));
            s.Add(new Sender(145f, 102f, 27.5f));


            var res = s.Result;
            foreach (Sender sender in res)
            {
                Console.WriteLine(sender);
            }
            Console.ReadLine();
        }
    }
}

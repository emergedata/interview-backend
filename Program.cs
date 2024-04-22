using System;

namespace InterviewProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var service = new Service();
            var a = service.E(1);
            Console.WriteLine($"Blog: {a.BlogId}");
            Console.WriteLine(service.A(1));
            Console.WriteLine("Latest: " + service.B(1));
            Console.Write("Enter a post to see details: ");
            var input = Console.ReadLine();
            Console.WriteLine(service.D(input));
        }
    }
}

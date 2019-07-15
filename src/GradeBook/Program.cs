using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new double[3];
            numbers[0] = 12.7;
            numbers[1] = 54.7;
            numbers[2] = 87.7;

            var result = numbers[0] + numbers[1] + numbers[2];

            Console.WriteLine(result);

            if (args.Length > 0) {
                Console.WriteLine($"Hello, {args[0]}!");
            } else {
                Console.WriteLine("Hello World!");
            }
        }
    }
}

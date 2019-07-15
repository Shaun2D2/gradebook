using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new List<double>() { 100, 90.5, 60.6 };
            grades.Add(85.5);

            var result = 0.0;
            foreach(var number in grades) {
                result += number;
            }

            result /= grades.Count;

            Console.WriteLine($"The average grade is {result:N1}");

            if (args.Length > 0) {
                Console.WriteLine($"Hello, {args[0]}!");
            } else {
                Console.WriteLine("Hello World!");
            }
        }
    }
}

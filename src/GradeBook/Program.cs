using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Shaun's gradebook");

            book.addGrade(89.1);
            book.addGrade(15.1);
            book.addGrade(67.1);

            var grades = new List<double>() { 100, 90.5, 60.6 };
            grades.Add(85.5);



            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            foreach(var number in grades) {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }

            result /= grades.Count;

            Console.WriteLine($"The average grade is {result:N1}");
            Console.WriteLine($"The lowest grade is {lowGrade:N1}");
            Console.WriteLine($"The highest grade is {highGrade:N1}");
        }
    }
}

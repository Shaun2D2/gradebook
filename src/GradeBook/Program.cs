﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Shaun's gradebook");

            while (true) {
                Console.WriteLine("Enter a grade or exit with 'q'");

                var input = Console.ReadLine();

                if (input == "q") {
                    break;
                }

                try {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                } catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }

            var stats = book.GetStatics();

            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The letter is {stats.Letter}");
        }
    }
}

using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Shaun's gradebook");

            book.AddGrade(89.1);
            book.AddGrade(15.1);
            book.AddGrade(67.1);
            book.ShowStatics();
        }
    }
}

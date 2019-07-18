using System;
using System.Collections.Generic;

namespace GradeBook {
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char letter)
        {
            switch(letter) {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);                
                    break;
            }
        }

        public void AddGrade(double grade) 
        {
            if (grade <= 100 && grade >= 0) {
                grades.Add(grade);
            } else {
                throw new ArgumentException($"Invalid Grade {nameof(grade)}");
            }

        }

        public Statistics GetStatics()
        {
            var result = new Statistics();

            result.High = double.MinValue;
            result.Low = double.MaxValue;
            
            var index = 0;
            do {
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];

                index += 1;
            } while (index < grades.Count);

            result.Average /= grades.Count;

            switch(result.Average) {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;                
            }

            return result;
        }

        // private string category;
        private List<double> grades;
        public String Name
        {
            get;
            set;
        }

        // public String Name
        // {
        //     get
        //     {
        //         return name;
        //     }
        //     set
        //     {
        //         name = value;
        //     }
        // }
        public String name;

        // readonly string category = "Science";
        // public const string CATEGORY = "Science";
    }
}

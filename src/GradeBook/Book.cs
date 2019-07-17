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

        public void AddGrade(double grade) 
        {
            grades.Add(grade);
        }

        public Statistics GetStatics()
        {
            var result = new Statistics();

            result.High = double.MinValue;
            result.Low = double.MaxValue;
            
            foreach(var grade in grades) {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }

            result.Average /= grades.Count;

            return result;
        }

        private List<double> grades;
        public String Name;
    }
}

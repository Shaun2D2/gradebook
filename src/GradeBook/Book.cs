using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook {
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject 
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name {
            get;
            set;
        }
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatics();
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"./{Name}.txt")) {
                writer.WriteLine(grade);

                if (GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatics()
        {
            throw new NotImplementedException();
        }
    }

    public class InMemoryBook : Book
    {

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
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

        public override void AddGrade(double grade) 
        {
            if (grade <= 100 && grade >= 0) {
                grades.Add(grade);

                if(GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                }
            } else {
                throw new ArgumentException($"Invalid Grade {nameof(grade)}");
            }

        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatics()
        {
            var result = new Statistics();

            // result.High = double.MinValue;
            // result.Low = double.MaxValue;
            
            var index = 0;
            do {
                result.Add(grades[index]);
                // result.Average += grades[index];

                index += 1;
            } while (index < grades.Count);

            return result;
        }

        // private string category;
        private List<double> grades;

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

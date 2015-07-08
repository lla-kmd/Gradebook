using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Gradebook
    {
        public Gradebook(string name = "No Name")
        {
            _name = name;
            _grades = new List<float>();
        }
        public void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
            }
        }

        public void WriteGrades(TextWriter textWriter)
        {
            textWriter.WriteLine("Grades:");

            foreach (float grade in _grades)
            {
                textWriter.WriteLine(grade);
            }
            textWriter.WriteLine("************");
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            float sum = 0f;

            foreach (float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum = sum + grade;
            }

            stats.AverageGrade = sum / _grades.Count;

            return stats;
        }

        private string _name; // Field

        public string Name // Property
        {
            get
            {
                return _name;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    var oldValue = _name;
                    _name = value;
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.OldValue = oldValue;
                    args.NewValue = value;
                    NameChanged(this, args);
                }
                else
                {
                    throw new ArgumentException("Errrror!!");
                }
            }
        }

        public event NamedChangedDelegate NameChanged;

        private List<float> _grades;
    }

}
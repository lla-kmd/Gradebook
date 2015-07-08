using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");

            Gradebook book = new Gradebook("Fisk");

            book.AddGrade(20.8f);
            book.AddGrade(20.9f);
            book.AddGrade(77.1f);
            book.AddGrade(50f);
            book.WriteGrades(Console.Out);

            Console.WriteLine("");

            GradeStatistics stats = book.ComputeStatistics();

            book.NameChanged += OnNameChanged; //Subscribe
            book.NameChanged += OnNameChanged; //Subscribe
            book.NameChanged += OnNameChanged2; //Subscribe
            book.NameChanged -= OnNameChanged; //Unsubscribe

            book.Name = "Hest";
            book.Name = "Pony";

            WriteNames(book.Name);

            Console.WriteLine("");

            Console.WriteLine("Your average grade:" + stats.AverageGrade);
            Console.WriteLine("Your highest grade" + stats.HighestGrade);
            Console.WriteLine("Your lowest grade" + stats.LowestGrade);
            Console.WriteLine("Your grade is {0}, which means {1}", stats.LetterGrade, stats.Description);

            Console.WriteLine("");

            try
            {
                book.Name = "";
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("The name is not changed due to a blank input");
            }

        }

        private static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("The name is now:");
        }

        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.OldValue, args.NewValue);
        }

        private static void WriteNames(string name)
        {
            Console.WriteLine(name);
        }
    }
}

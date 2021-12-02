using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportCardGenerator
{
    class Student
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public int? MidtermGrade { get; set; }
        public int FinalGrade { get; set; }
        public char? MidtermLetterGrade { get; set; }
        public char FinalLetterGrade { get; set; }

        #endregion

        public Student(int id)
        {
            int? test;

            Id = id;
            Name = StudentName();
            MidtermGrade = QueryGrade();
            test = QueryGrade();
            if (test is null)
            {
                throw new NullReferenceException("Final Grade cannot be null");
            }
            else
                FinalGrade = (int)test;

            if (MidtermGrade is not null)
            {
                MidtermLetterGrade = GenerateLetterGrade((int)MidtermGrade);
            }
            else
                MidtermLetterGrade = null;

            FinalLetterGrade = GenerateLetterGrade((int)FinalGrade);
        }

        public Student(int id, string name)
        {
            int? test;
            Id = id;
            Name = name;

            MidtermGrade = QueryGrade();
            test = QueryGrade();
            if (test is null)
            {
                throw new NullReferenceException("Final Grade cannot be null");
            }
            else
                FinalGrade = (int)test;

            if (MidtermGrade is not null)
            {
                MidtermLetterGrade = GenerateLetterGrade((int)MidtermGrade);
            }
            else
                MidtermLetterGrade = null;

            FinalLetterGrade = GenerateLetterGrade((int)FinalLetterGrade);
        }

        public Student(int id, string name, int? midtermGrade, int finalGrade)
        {
            Id = id;
            Name = name;
            if (midtermGrade == null)
            {
                MidtermGrade = midtermGrade;
            }

            FinalGrade = finalGrade;
        }

        private string StudentName()
        {
            string? name;

            Console.WriteLine("Please enter the student name: ");
            name = Console.ReadLine();

            if (name != null)
            {
                return name;
            }
            else
            {
                throw new NullReferenceException($"Entered Value {typeof(string)} is Null");
            }
        }

        private int? QueryGrade()
        {
            int amount;
            bool test;
            string? testInput;

            Console.WriteLine("Please enter a grade: ");
        test: testInput = Console.ReadLine();

            test = Int32.TryParse(testInput, out amount);
            if (!test)
            {
                Console.WriteLine("Please enter a valid number");
                goto test;
            }

            return amount;
        }

        private char GenerateLetterGrade(int grade)
        {
            char? letterGrade = null;

            switch (grade)
            {
                case int n when (n <= 100 && n >= 90):
                    letterGrade = 'A';
                    break;
                case int n when (n >= 80 && n <= 89):
                    letterGrade = 'B';
                    break;
                case int n when (n >= 70 && n <= 79):
                    letterGrade = 'C';
                    break;
                case int n when (n >= 60 && n <= 69):
                    letterGrade = 'D';
                    break;
                case int n when (n >= 0 && n <= 59):
                    letterGrade = 'F';
                    break;
                default:
                    System.Console.WriteLine("LetterGrade: " + grade + " Does not exist!");
                    throw new ArgumentOutOfRangeException("Grade is over 100% or less than 0%");
            }

            return (char)letterGrade;
        }

        public void DisplayStudentInfo(Student student)
        {
            System.Console.WriteLine("Student Id: {0}", student.Id);
            System.Console.WriteLine("Student Name: {0}", student.Name);
            System.Console.WriteLine("Student Midterm Grade: {0} \n Letter Grade: {1}", student.MidtermGrade, student.MidtermLetterGrade);
            System.Console.WriteLine("Student Final Grade: {0} \n Letter Grade: {1}", student.FinalGrade, student.FinalLetterGrade);
        }




    }
}

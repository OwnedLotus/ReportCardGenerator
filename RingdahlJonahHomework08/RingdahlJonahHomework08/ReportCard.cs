using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RingdahlJonahHomework08
{
    class ReportCard
    {
        #region Properties
        public int Id { get; set; }
        public string studentName { get; set; }
        public int midtermGrade 
        {
            get{return midtermGrade;}
            set 
            { 
                if(value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 0 and 100");
            }
        }
        public int finalGrade 
        {
            get{return finalGrade;}
            set 
            { 
                if(value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 0 and 100");
            }
        }
        public char midtermLetterGrade { get; set; }
        public char finalLetterGrade { get; set; }
        #endregion


        #region Full ReportCard Override
        public ReportCard(int id, string studentName, int midtermGrade, int finalGrade, char midtermLetterGrade, char finalLetterGrade)
        {
            this.Id = id;
            this.studentName = studentName;
            this.midtermGrade = midtermGrade;
            this.finalGrade = finalGrade;
            this.midtermLetterGrade = midtermLetterGrade;
            this.finalLetterGrade = finalLetterGrade;
        }
        #endregion

        #region LetterGrade Finding Override
        public ReportCard(int id, string studentName, int midtermGrade, int finalGrade)
        {
            this.Id = id;
            this.studentName = studentName;
            this.midtermGrade = midtermGrade;
            this.finalGrade = finalGrade;
            
            midtermLetterGrade = LetterGrade(midtermGrade);
            finalLetterGrade = LetterGrade(finalLetterGrade);
        }
        #endregion

        #region midtermGrade not availble Override
        public ReportCard(int id, string studentName, int finalGrade)
        {
            this.Id = id;
            this.studentName = studentName;
            this.finalGrade = finalGrade;
            
            finalLetterGrade = LetterGrade(finalLetterGrade);
        }
        #endregion

        #region Number Grade not availble Override
        public ReportCard(int id, string studentName)
        {
            this.studentName = studentName;
        }
        #endregion

        #region Constructor Method-Based
        public ReportCard(int id)
        {
            this.Id = id;

            this.studentName = StudentName();
            this.midtermGrade = Grade(1);
            this.finalGrade = Grade(2);
        }
        #endregion

        #region Methods

        public string StudentName()
        {
            string name;

            System.Console.WriteLine("Please Enter the Student Name: ");
            name = Console.ReadLine();

            return name;
        }

        public int Grade(int num)
        {
            int amount;
            bool test;
            string input;

            if (num == 1)
            {
                System.Console.WriteLine("Please Enter the Midterm Grade: ");
                input: input = Console.ReadLine();

                test = Int32.TryParse(input, out amount);
                if (!test)
                {
                    Console.WriteLine("Please Enter a Valid Number!");
                    goto input;
                }
                num = amount;

            }
            else if (num == 2)
            {
                System.Console.WriteLine("Please Enter the FinalGrade: ");
                input: input = Console.ReadLine();

                test = Int32.TryParse(input, out amount);
                if (!test)
                {
                    Console.WriteLine("Please Enter a Valid Number!");
                    goto input;
                }

                num = amount;
            }

            return num;
        }
        

        public char LetterGrade(int grade)
        {
            char letterGrade;

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
                case int n when (n >= 0 && n <= 59) :
                    letterGrade = 'F';
                    break;
                default:
                    System.Console.WriteLine("LetterGrade: "+ grade + " Does not exist!");
                    throw new ArgumentOutOfRangeException("Grade is over 100% or less than 0%");
            }

            return letterGrade;
        }
        #endregion
    }
}

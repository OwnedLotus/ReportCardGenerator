/*
Create a program as a Console Application that attempts to create several valid and invalid ReportCard objects.

Immediately after each instantiation attempt, handle any thrown exceptions by displaying an error message. 

Create a ReportCard class with four fields for a student name, a numeric midterm grade, a numeric final exam grade, and letter grade.

The ReportCard constructor requires values for the name and two numeric grades and determines the letter grade.

Upon construction, throw an ArgumentException if the midterm or final exam grade is less than 0 or more than 100. 

The letter grade is based on the arithmetic average of the midterm and final exams using a grading scale of 
A for an average of 90 to 100, B for 80 to 90, C for 70 to 80, D for 60 to 70, and F for an average below 60.

Display all the data if the instantiation is successful.
*/
using System;
using System.Collections.Generic;

namespace RingdahlJonahHomework08
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Variables

            string input;
            int numberOfReports;
            bool test;

            #endregion
            
            #region Entering User Input
            System.Console.WriteLine("Please Enter the Amount of ReportCards:");
            READ_ERROR:input = Console.ReadLine();

            test = Int32.TryParse(input, out numberOfReports); //tryparsing statement that returns a bool if the method executes and returns the parsed number
            
            if (!test || (bool)CheckIfBlank(input)) //tests if test is not false which means the parser works and checks if the input was empty from CheckIfBlank method
            {
                System.Console.WriteLine("Given Input was not accepted: Please Try Again!");
                goto READ_ERROR;
            }

            
            #endregion

            var reportcardTable = new List<ReportCard>(); // creates an id table set to the number inputted by the user

            for (int i = 0; i < numberOfReports; i++) //individually creates the individual reportcards
            {
                reportcardTable.Add(ReportCard );// based on the constructor, it asks the user for the necessary information
            }

            Console.WriteLine("Please Enter the Values for the Student: ");
            
            foreach (ReportCard students in reportcardTable) //prints out information on the students
            {
                int i = 1;
                reportcardTable.Add(i, new ReportCard(i));
                System.Console.WriteLine("Student Id: {0}", students.Id);
                System.Console.WriteLine("Student Name: {0}", students.studentName);
                System.Console.WriteLine("Student Midterm Grade: {0} \n Letter Grade: {1}", students.midtermGrade, students.midtermLetterGrade);
                System.Console.WriteLine("Student Final Grade: {0} \n Letter Grade: {1}", students.midtermGrade, students.midtermLetterGrade);
                i++;
            }

        }

        #region Public Methods
        ///This method returns the value of a bool while given
        static bool? CheckIfBlank(params object[] obj) 
        {
            bool? isBlank = null; // nullable bool for error checking, if everything should not be null if so, program throws an null exception

            foreach (var item in obj) // Iterates throw the given arguments to check if an argument is blank
            {
                if ((item.ToString() == null) || (item.ToString() == "\n") || (item.ToString() == "\0")) // If user enters a "next line character '\n'" or a blank space program will set bool to true
                {
                    isBlank = true;
                }
                else  isBlank = false;
            }

            if (isBlank == null)
                throw new NullReferenceException($"(nameof{isBlank}) is Null");        
                
            //returns null if error has occurred
            return isBlank;
        }
        
        #endregion
    }
}
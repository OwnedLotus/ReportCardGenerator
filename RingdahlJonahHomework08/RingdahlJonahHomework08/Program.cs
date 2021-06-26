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
using System.Collections;

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
            bool? isBlank; //catching if the input the user entered is blank

            #endregion
            
            #region Entering User Input
            System.Console.WriteLine("Please Enter the Amount of ReportCards to be made");
            input:input = Console.ReadLine();

            test = Int32.TryParse(input, out numberOfReports);
            
            if (!test || (bool)CheckIfBlank(input))
            {
                System.Console.WriteLine("Given Input was not accepted: Please Try Again!");
                goto input;
            }

            
            #endregion

            Hashtable reportcardTable = new Hashtable(numberOfReports);


            Console.WriteLine("Please Enter the Values for the Student: ");
            foreach (ReportCard student in reportcardTable.Values)
            {
                
            }

        }

        #region Public Methods
        ///This method returns the value of a bool while given
        static bool? CheckIfBlank(params object[] obj) 
        {
            bool? blank = null;

            foreach (var item in obj)
            {
                if ((string)item == "\n" || (string)item == " ")
                {
                    blank = true;
                }
                else  blank = false;
            }

            if (blank is null)
                throw new NullReferenceException($"(nameof{blank}) is Null"); 
                
                
            //returns null if error has occurred
            return blank;
        }

/*
        static bool BlankToNonNull(bool? blank)
        {
            bool check = true;

            if (blank != null)
            {
                check = (bool)blank;
            }

            return check;
        }
*/
        #endregion
    }
}
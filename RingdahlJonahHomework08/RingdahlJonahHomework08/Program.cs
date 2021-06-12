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
using System.Threading;

/* The point of this program is to create several objects of the users choosing that are reportcards.
 * They will throw exceptions if there is something wrong with the logic that has been entered.
 * It does its own conversion and error handling through the ReportCard Class.
 * My Original Idea was to make the Object array dynamic but from what I have read it seems to be impossible to
 * dynamically name objects in loops
 */

namespace RingdahlJonahHomework08
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int amount;
            bool test;

            System.Console.WriteLine("Please Enter the Amount of ReportCards to be made");
            input:input = Console.ReadLine();

            test = Int32.TryParse(input, out amount);
            if (!test)
            {
                Console.WriteLine("Please Enter a Valid Number!");
                goto input;
            }

            List<ReportCard> reportCards = new List<ReportCard>(amount);

            for (int i = 0; i < reportCards.Count; i++)
            {
                string name;
                int mid, fin;
                char midLetter, finLetter;

                name = reportCards[i].StudentName();
                mid = reportCards[i].Grade(1);
                fin = reportCards[i].Grade(2);

                midLetter = reportCards[i].LetterGrade(mid);
                finLetter = reportCards[i].LetterGrade(fin);

                reportCards.Add(new ReportCard(i, name, mid, fin, midLetter, finLetter));
            }

        }
    }
}
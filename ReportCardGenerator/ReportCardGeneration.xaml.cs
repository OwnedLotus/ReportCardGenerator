using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace ReportCardGenerator
{
    /// <summary>
    /// Interaction logic for ReportCardGeneration.xaml
    /// </summary>
    public partial class ReportCardGeneration : Window
    {
        List<Student> students = new List<Student>();

        string fileName = "ReportsPrintout.txt";
        string path = "D:/GitHub/ReportCardGenerator/";

        public ReportCardGeneration()
        {
            InitializeComponent();
          
        }

        private void subButton_Click(object sender, RoutedEventArgs e)
        {
            string fName, lName;
            int mGrade, fGrade;
            bool mCase, fCase;

            fName = fNameTxt.Text;
            lName = lNameTxt.Text;

            mCase = Int32.TryParse(midGradeTxt.Text, out mGrade);
            fCase = Int32.TryParse(finGradeTxt.Text, out fGrade);

            if (!mCase || !fCase)
            {
                Console.WriteLine("Grade was not accepted! Please Try again");
            }
            else if (fName == null || lName == null)
            {
                Console.WriteLine("Name was not entered! Please enter the name");
            }
            else
            {
                fName = CleanString(fName);
                lName = CleanString(lName);


                string fullName = fName + " " + lName;

                students.Add(new Student(students.Count, fullName, mGrade, fGrade));
            }
        }

        string CleanString(string s)
        {
            s = s.Trim();
            s = s.ToLower();
            s = FirstToUpper(s);

            if(CheckIfBlank(s) == true)
            {
                return s;
            }
            return new string(s + "Error!");
        }

        string FirstToUpper(string str)
        {
            char[] letters = str.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);

            return new string(letters);
        }

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
                else
                    isBlank = false;
            }

            if (isBlank == null)
                throw new NullReferenceException($"(nameof{isBlank}) is Null");

            //returns null if error has occurred
            return isBlank;
        }

        private void generateListButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (TextWriter tw = new StreamWriter(path))
            {
                File.Create(fileName);
                foreach (Student student in students)
                {
                    tw.WriteLine(string.Format($"Student Id: {student.Id}"));
                    tw.WriteLine(string.Format($"Student Name: {student.Name}"));
                    tw.WriteLine(string.Format($"Student Midterm Grade: {student.MidtermGrade}"));
                    tw.WriteLine(string.Format($"Student Midterm Letter Grade: {student.MidtermLetterGrade}"));
                    tw.WriteLine(string.Format($"Student Final Grade: {student.FinalGrade}"));
                    tw.WriteLine(string.Format($"Student Final Letter Grade: {student.FinalLetterGrade}"));
                }
            }
            
        }
    }
}

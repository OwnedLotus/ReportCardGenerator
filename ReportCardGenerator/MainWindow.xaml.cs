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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReportCardGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region Variables

            string input;
            int numOfRepos;
            bool test;
            #endregion



            #region User Input

            input = numBox.Text;

            test = Int32.TryParse(input, out numOfRepos);

            /*if (!test || (bool)CheckIfBlank(input))
            {//Holding error catcher
                System.Console.WriteLine("Given Input was not accepted: Please Try Again!");
                throw new Exception($"(nameof{input}) is Invalid. Please enter Legal input");
            }*/
            #endregion
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
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
                else
                    isBlank = false;
            }

            if (isBlank == null)
                throw new NullReferenceException($"(nameof{isBlank}) is Null");

            //returns null if error has occurred
            return isBlank;
        }
        #endregion

        private void generateButton_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
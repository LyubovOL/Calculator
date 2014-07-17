using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Text.RegularExpressions;
using Logic;
using Storage;

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int accuracy = 3;
        private Logic.CalculatorLogic.Operation operation;
        IStorage storage = new StoreInFile(ConfigurationManager.AppSettings["path"]);
        private string NumberAtBeginning = "^\\d{1,10},{0,1}\\d{0,10}[ ]{1}$";
        
        public MainWindow()
        {
            InitializeComponent();
            Result.Clear();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(Result.Text, "^-{0,1}\\d{1,10},{0,1}\\d{0,10}$"))
            {
                Clear();
            }
            var clicked = (Button)sender;
            Result.Text += clicked.Content;
        }
        private void Point_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            Result.Text += (Result.Text == String.Empty || Regex.IsMatch(Result.Text, "[ ]{1}$")) ? "0," : ",";
        }

        private void Null_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            Result.Text += (Result.Text == "0" || Regex.IsMatch(Result.Text, "[ ]{1}[0]{1}$")) ? String.Empty : "0";
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var clicked = (Button)sender;
            Result.Text += (Result.Text == String.Empty || Regex.IsMatch(Result.Text, "[*+-/]{1}$")) ? 
                String.Empty : String.Format(" {0} ",clicked.Content);
            switch ((String)clicked.Content)
            {
                case "/":
                    operation = Logic.CalculatorLogic.Operation.Division;
                    break;
                case "*":
                    operation = Logic.CalculatorLogic.Operation.Multiplication;
                    break;
                case "+":
                    operation = Logic.CalculatorLogic.Operation.Addition;
                    break;
            }
        }

        private void Subtraction_Click(object sender, RoutedEventArgs e)
        {
            //if (!Regex.IsMatch(Result.Text, "^\\d{1,10},{0,1}\\d{0,10}$"))
             //   Clear();
            Result.Text += Regex.IsMatch(Result.Text, "-{1}$") ? String.Empty : " - ";
            operation = Logic.CalculatorLogic.Operation.Subtraction;
        }

        private void Equally_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(Result.Text, "^-{0,1}\\d{1,10},{0,1}\\d{0,10} [*+-/]{1} -{0,1}\\d{1,10},{0,1}\\d{0,10}$"))
            {
                string[] operands = Result.Text.Split(new char[] {' '});
                var calc = new Logic.CalculatorLogic(double.Parse(operands[0]), double.Parse(operands[2]), operation,
                    accuracy);
                Result.Text = Math.Round(calc.Result, accuracy).ToString();
                storage.Write(calc.ToString());
                operation = Logic.CalculatorLogic.Operation.Equally;
            }
            else
            {
                MessageBox.Show("Incorrect input");
                Result.Clear();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Result.Clear();
        }

        private void ChangedAccuracy(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(Accuracy.Text, "^\\d{1,2}$") && (int.Parse(Accuracy.Text) >= 0) &&
                (int.Parse(Accuracy.Text) <= 15))
            {
                var textBox = sender as TextBox;
                int value;
                if (int.TryParse(textBox.Text, out value))
                {
                    if (accuracy == value)
                        return;

                    accuracy = value;
                }
            }
            else
            {
                Accuracy.Clear();
            }
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            string[] str = storage.Read(int.Parse(ConfigurationManager.AppSettings["countString"]));
            var history = new History(str);
            history.Show();
        }

        private void Clear()
        {
            if (operation == CalculatorLogic.Operation.Equally)
                Result.Clear();
        }
    }
}

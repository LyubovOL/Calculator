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
using Calculator;
using System.Text.RegularExpressions;
using Storage;

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _firstOperand = 0.0;
        private double _secondOperand = 0.0;
        private int _accuracy = 3;
        private Calculator.Calculator.Operation _operation;
        IStorage storage = new StoreInFile(); 
        public MainWindow()
        {
            InitializeComponent();
            Result.Clear();
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += Result.Text == String.Empty ? "0." : ".";
        }

        private void Null_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += Result.Text == "0" ? String.Empty : "0";
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "1";
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "2";
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "3";
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "4";
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "5";
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "6";
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "7";
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "8";
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "9";
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += Result.Text == String.Empty ? String.Empty : "/";
            _operation = Calculator.Calculator.Operation.Division;
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += Result.Text == String.Empty ? String.Empty : "*";
            _operation = Calculator.Calculator.Operation.Multiplication;
        }

        private void Subtraction_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += "-";
            _operation = Calculator.Calculator.Operation.Subtraction;
        }

        private void Addition_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += Result.Text == String.Empty ? String.Empty : "+";
            _operation = Calculator.Calculator.Operation.Addition;
        }

        private void Equally_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(Result.Text, "^-{0,1}\\d{1,10},{0,1}\\d{0,10}[*+-/]{1}\\d{1,10},{0,1}\\d{0,10}$"))
            {
                string[] operands = Result.Text.Split(new char[] {'+', '-', '*', '/'});
                var calc = new Calculator.Calculator(double.Parse(operands[0]), double.Parse(operands[1]), _operation,
                    _accuracy);
                Result.Text = Math.Round(calc.Result, _accuracy).ToString();
                storage.Write(calc.ToString(), ConfigurationManager.AppSettings["path"]);
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

        private void Accuracy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(Accuracy.Text, "^\\d{1,10}$"))
            {
                _accuracy = int.Parse(Accuracy.Text);
            }
            else
            {
                Accuracy.Clear();
            }
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            string[] str = storage.Read(ConfigurationManager.AppSettings["path"], int.Parse(ConfigurationManager.AppSettings["countString"]));
            var history = new History(str);
            history.Show();
        }
    }
}

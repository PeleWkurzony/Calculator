using System;
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
 
namespace Calculator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private double lastValue = 0.0;
        private char lastOperator = '\0';
        private bool calculatedValue = false;

        private void Num_Click(object sender, RoutedEventArgs e) {
            Button btn = (Button)sender;
            int value = int.Parse(btn.Content.ToString());

            if (calculatedValue) {
                output_.Text = value.ToString();
                calculatedValue = false;
            } 
            else {
                output_.Text += value.ToString();
            }
            string output = output_.Text.ToString();
            if (output[0] == '0' && output.Length > 1) {

                string tmp = output.Remove(0, 1);
                output_.Text = tmp;
            }
        }
        private void ButtonDot_Click(object sender, RoutedEventArgs e) {
            foreach (char chr in output_.Text.ToString()) {
                if (chr == '.') {
                    return;
                }
            }
            output_.Text += '.';
        }
        private void buttonC_Click(object sender, RoutedEventArgs e) {
            output_.Text = "0";
            lastValue = 0.0;
            lastOperator = '\0';
        }
        private void Calculate(char oper, double acctValue) {

            double result = 0.0;
            if (oper == '+') result = lastValue + acctValue;
            else if (oper == '-') result = lastValue - acctValue;
            else if (oper == '*') result = lastValue * acctValue;
            else if (oper == '÷') result = lastValue / acctValue;

            output_.Text = result.ToString();
            calculatedValue = true;

            lastValue = result;
        }
        private void Operator_Click(object sender, RoutedEventArgs e) {
            Button btn = (Button)sender;
            char acctOperator;
            double acctValue;
            Char.TryParse(btn.Content.ToString(), out acctOperator);
            Double.TryParse(output_.Text.ToString(), out acctValue);

            if (acctOperator == '√') {
                double value;
                if (Double.TryParse(output_.Text.ToString(), out value)) {
                    double square = Math.Sqrt(value);
                    output_.Text = square.ToString();
                }
                return;
            }

            if (lastValue == 0.0 && acctValue != 0.0 && lastOperator == '\0') {
                output_.Text = "0";
                lastValue = acctValue;
                lastOperator = acctOperator;
                return;
            } 
            else if (lastValue != 0.0 && acctValue == 0.0) {

                lastValue = acctValue;
                output_.Text = lastValue.ToString();
                return;

            } 
            else if (acctValue != 0.0 && lastOperator != '\0') {
                Calculate(lastOperator, acctValue);
                lastOperator = acctOperator;
                return;
            }
            
        }
        private void Calculate_Click(object sender, RoutedEventArgs e) {
            Calculate(lastOperator, Double.Parse(output_.Text.ToString()));
        }
        private void Exit_Click(object sender, RoutedEventArgs e) {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
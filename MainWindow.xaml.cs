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

        private double lastValue = 0;
        private char lastOperator = '\0';

        private void Num_Click(object sender, RoutedEventArgs e) {
            Button btn = (Button)sender;
            int value = int.Parse(btn.Content.ToString());
            if (lastValue != 0.0) {
                output_.Text = value.ToString();
            } else {
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
        private void Calculate() {

            double acctValue = 0.0;
            double result = 0.0;
            Double.TryParse(output_.Text, out acctValue);
            if (lastOperator == '+') result = lastValue + acctValue;
            else if (lastOperator == '-') result = lastValue - acctValue;
            else if (lastOperator == '*') result = lastValue * acctValue;
            else if (lastOperator == '÷') result = lastValue / acctValue;

            output_.Text = result.ToString();

            lastOperator = '\0';
            lastValue = 0.0;
        }
        private void Operator_Click(object sender, RoutedEventArgs e) {
            Button btn = (Button)sender;
            string oper = btn.Content.ToString();

            if (oper == "√") {
                double value;
                if (Double.TryParse(output_.Text.ToString(), out value)) {
                    double square = Math.Sqrt(value);
                    output_.Text = square.ToString();
                }
                return;
            }

            double tempOutput;
            Double.TryParse(output_.Text, out tempOutput);

            if (lastValue != 0.0 && tempOutput != 0.0) {
                Calculate();
                return;
            }
            if (lastValue == 0.0) {
                output_.Text = "0";
            }
            Char.TryParse(oper, out lastOperator);
            lastValue = tempOutput;
        }
        private void Calculate_Click(object sender, RoutedEventArgs e) {
            Calculate();
        }
    }
}
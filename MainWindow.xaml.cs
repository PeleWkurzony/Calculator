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

        double lastValue = 0;

        private void Num_Click(object sender, RoutedEventArgs e) {
            Button btn = (Button)sender;
            int value = int.Parse(btn.Content.ToString());
            output_.Text += value.ToString();

            string output = output_.Text.ToString();
            if (output[0] == '0' && output.Length > 1) {

                string tmp = output.Remove(0, 1);
                output_.Text = tmp;
            }
        }

        private void ButtonDot__Click(object sender, RoutedEventArgs e) {
            foreach (char chr in output_.Text.ToString()) {
                if (chr == '.') {
                    return;
                }
            }
            output_.Text += '.';
        }

        private void buttonC__Click(object sender, RoutedEventArgs e) {
            output_.Text = "";
            lastValue = 0.0;
        }

        private void Calculate() {
            int _;
            int last = 0;
            List<Double> values = new List<double>();
            List<char> chars = new List<char>();
            string txt = output_.Text;
            for (int i = 0; i < txt.Length; i++) {
                char chr = txt[i];
                if (!int.TryParse(chr.ToString(), out _)) {
                    string tmp = txt.Substring(last, i - last);
                    values.Add(Double.Parse(txt.Substring(last, i - last)));
                    last = i;
                    chars.Add(chr);
                    foreach (double d in values) {
                        Console.WriteLine(d);
                    }
                    foreach (char c in chars) {
                        Console.WriteLine(c);
                    }
                }
            }

        }

        private void Operator_Click(object sender, RoutedEventArgs e) {
            Button btn = (Button)sender;
            string oper = btn.Content.ToString();

            if (oper == "√") {
                Calculate();
                double value;
                if (Double.TryParse(output_.Text.ToString(), out value)) {
                    double square = Math.Sqrt(value);
                    output_.Text = square.ToString();
                }
            }

            output_.Text += oper;

        }
    }
}
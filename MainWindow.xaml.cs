using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WPF_app3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double result;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            partial.Content += (sender as Button).Content.ToString();
        } //Num

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (partial.Content.ToString().Length > 0)
                partial.Content = partial.Content.ToString().Remove(partial.Content.ToString().Length - 1);
        } //Del

        private void elem_Click(object sender, EventArgs e)
        {
            if (full.Content.ToString().Length == 0)
            {
                full.Content += partial.Content.ToString();
                result = double.Parse(partial.Content.ToString());
            }
            else if (partial.Content.ToString().Length > 0 && symbol.Content.ToString().Length > 0 && full.Content.ToString().Length > 0)
            {
                if (symbol.Content.ToString() != "=") full.Content += " " + symbol.Content + " " + partial.Content;
                if (symbol.Content.ToString() == "+") result += double.Parse(partial.Content.ToString());
                else if (symbol.Content.ToString() == "-") result -= double.Parse(partial.Content.ToString());
                else if (symbol.Content.ToString() == "X") result *= double.Parse(partial.Content.ToString());
                else if (symbol.Content.ToString() == "/") result /= double.Parse(partial.Content.ToString());
            }
            symbol.Content = (sender as Button).Content;
            if (symbol.Content.ToString() == "=")
            {
                partial.Content = result.ToString();
                return;
            }
            partial.Content = "";
        }

        private void ce_Click(object sender, RoutedEventArgs e)
        {
            partial.Content = "";
            symbol.Content = "";
        }
        private void c_Click(object sender, RoutedEventArgs e)
        {
            partial.Content = "";
            full.Content = "";
            symbol.Content = "";
        }
    }
}

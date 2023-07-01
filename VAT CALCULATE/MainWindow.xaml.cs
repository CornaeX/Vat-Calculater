using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VAT_CALCULATE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnVAT_OUT_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as ToggleButton;
            if (clickedButton == btnVAT_OUT)
            {
                // Clicked VAT OUT button
                btnVAT_IN.IsChecked = false; // Uncheck VAT IN button
            }
            else if (clickedButton == btnVAT_IN)
            {
                // Clicked VAT IN button
                btnVAT_OUT.IsChecked = false; // Uncheck VAT OUT button
            }
        }

        private void btnVAT_IN_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as ToggleButton;
            if (clickedButton == btnVAT_IN)
            {
                // Clicked VAT IN button
                btnVAT_OUT.IsChecked = false; // Uncheck VAT OUT button
            }
            else if (clickedButton == btnVAT_OUT)
            {
                // Clicked VAT OUT button
                btnVAT_IN.IsChecked = false; // Uncheck VAT IN button
            }
        }
        
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (btnVAT_OUT.IsChecked == true)
            {
                if (int.TryParse(Intxt_Price.Text, out int IntxtPrice))
                {
                    // Use the number stored in the 'IntxtPrice' variable
                    Outtxt_ServicePrice.Text = IntxtPrice.ToString("N2");

                    Outtxt_Vat.Text = (IntxtPrice * 0.07).ToString("N2");

                    Outtxt_SumVat.Text = ((IntxtPrice * 0.07) + IntxtPrice).ToString("N2");

                }
            }
            else if (btnVAT_IN.IsChecked == true)
            {
                if (int.TryParse(Intxt_Price.Text, out int IntxtPrice))
                {
                    // Use the number stored in the 'IntxtPrice' variable
                    double vat = IntxtPrice * (7.0 / 107.0);
                    Outtxt_ServicePrice.Text = (IntxtPrice - vat).ToString("N2");

                    Outtxt_Vat.Text = vat.ToString("N2");

                    Outtxt_SumVat.Text = IntxtPrice.ToString("N2");

                }
            }
        }
    }
}

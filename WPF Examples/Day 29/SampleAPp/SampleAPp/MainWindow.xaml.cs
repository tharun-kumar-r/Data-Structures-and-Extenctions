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

namespace SampleAPp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            hideerror();
        }

        public void hideerror()
        {
            msgcountry.Visibility = Visibility.Hidden;
            msgfirst.Visibility = Visibility.Hidden;
            msggender.Visibility = Visibility.Hidden;
            msglast.Visibility = Visibility.Hidden;
            msgmiddl.Visibility = Visibility.Hidden;
            msggedate.Visibility = Visibility.Hidden;
           
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            if (firstname.Text != "" && middlename.Text != "" && lastname.Text != "" &&
    (malea.IsChecked == true || female.IsChecked == true) &&
    datetimeA.SelectedDate != null && country.Text != "")
            {
               
                string message = $"Firstname: {firstname.Text}\n" +
                                 $"Middlename: {middlename.Text}\n" +
                                 $"Lastname: {lastname.Text}\n" +
                                 $"Gender: {(malea.IsChecked == true ? "Male" : "Female")}\n" +
                                 $"Date: {datetimeA.SelectedDate.Value.ToString("yyyy-MM-dd")}\n" +
                                 $"Country: {country.Text}";
                hideerror();
                MessageBox.Show(message, "Form Data", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

                if (firstname.Text == "")
                {
                    msgfirst.Visibility = Visibility.Visible;
                }
                else
                {
                    msgfirst.Visibility = Visibility.Hidden;
                }
                if (middlename.Text == "")
                {
                    msgmiddl.Visibility = Visibility.Visible;
                }
                else
                {
                    msgmiddl.Visibility = Visibility.Hidden;
                }
                if (lastname.Text == "")
                {
                    msglast.Visibility = Visibility.Visible;
                }
                else
                {
                    msglast.Visibility = Visibility.Hidden;
                }
                if (malea.IsChecked == false && female.IsChecked == false)
                {
                    msggender.Visibility = Visibility.Visible;
                }
                else
                {
                    msggender.Visibility = Visibility.Hidden;
                }
                if (datetimeA.SelectedDate == null)
                {
                    msggedate.Visibility = Visibility.Visible;
                }
                else
                {
                    msggedate.Visibility = Visibility.Hidden;
                }
                if (country.Text == "")
                {
                    msgcountry.Visibility = Visibility.Visible;
                }
                else
                {
                    msgcountry.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}

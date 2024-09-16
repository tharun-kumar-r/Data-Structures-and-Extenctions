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

namespace Employee_App
{
    /// <summary>
    /// Interaction logic for create.xaml
    /// </summary>
    public partial class Update : Page
    {
        public Update()
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
                hideerror();
                try
                {
                    EMployeeDbEntities1 dbc = new EMployeeDbEntities1();
                   

                  

                    var c = dbc.Employees.FirstOrDefault(x => x.ID == 1);
                    c.fname = firstname.Text;
                    c.lname = lastname.Text;
                    c.mname = middlename.Text;
                    c.country = country.Text;
                    c.gender = malea.IsChecked == true ? "Male" : "Female"; 
                    c.dated = datetimeA.Text;
                    dbc.SaveChanges();
                    MessageBox.Show("Employee Updated to Database", "Form Data", MessageBoxButton.OK, MessageBoxImage.Information);

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void findbtn_Click(object sender, RoutedEventArgs e)
        {
            EMployeeDbEntities1 dbc = new EMployeeDbEntities1();

            int ids = Convert.ToInt32(empid.Text);
            var c = dbc.Employees.FirstOrDefault(x => x.ID == ids);
            firstname.Text = c.fname;
            lastname.Text = c.lname;
            middlename.Text = c.mname;
            country.Text = c.country;
          
            datetimeA.Text = c.dated;
        }
    }
}

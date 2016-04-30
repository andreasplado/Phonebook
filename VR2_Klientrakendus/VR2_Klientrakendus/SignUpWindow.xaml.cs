using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VR2_Klientrakendus.Models;
using VR2_Klientrakendus.ViewModels;

namespace VR2_Klientrakendus
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        SignUpWindowVM _vm;

        public SignUpWindow()
        {
            InitializeComponent();
            this.Loaded += Window1_Loaded;
        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            this._vm = new SignUpWindowVM();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void button_SignUp(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                UserName = TxtUserName.Text,
                Password = TxtPassword.Password,
                Email = TxtEmail.Text,
                Name = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                Age = TxtAge.Text,
                Added =  DateTime.Now
            };
            _vm.AddUser(user);
            MessageBox.Show("User created successfully");
            this.Hide();
        }
    }
}

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
using System.Windows.Shapes;
using VR2_Klientrakendus.ViewModels;

namespace VR2_Klientrakendus
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {
        private UserProfileVM _vm;
        public UserProfile()
        {
            InitializeComponent();
            this.Loaded += UserProfile_Loaded;
        }

        private void UserProfile_Loaded(object sender, RoutedEventArgs e)
        {
            this._vm = new UserProfileVM();
            this._vm.LoadUserById(2);
            ShowUserInfo();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Save_changes_Click(object sender, RoutedEventArgs e)
        {
            _vm.UpdateUser(_vm.User, _vm.User.UserId);
            MessageBox.Show("User updated successfully");
            this.Hide();
        }

        private void ShowUserInfo()
        {
            TxtUsername.Text = _vm.User.UserName;
            TxtName.Text = _vm.User.Name;
            TxtLastName.Text = _vm.User.LastName;
            TxtAge.Text = _vm.User.Age;
            TxtEmail.Text = _vm.User.Email;
            TxtEditEmail.Text = _vm.User.Email;
            TxtEditAge.Text = _vm.User.Age;
            TxtEditFirstName.Text = _vm.User.Name;
            TxtEditLastName.Text = _vm.User.LastName;
            TxtEditUsername.Text = _vm.User.UserName;
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            _vm.DeleteUser(2);
            MessageBox.Show("User with id 2 deleted successfully");
        }
    }
}

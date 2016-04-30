using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using VR2_Klientrakendus.Models;
using VR2_Klientrakendus.ViewModels;

namespace VR2_Klientrakendus
{
    /// <summary>
    /// Interaction logic for AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        private readonly AddContactVM _vm;
        public AddContactWindow()
        {
            InitializeComponent();
            _vm = new AddContactVM();
        }

        private void BtnAddContact_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                ContactName = TxtContactName.Text,
                ContactLastName = TxtContactLastName.Text,
                ContactValue = TxtContactValue.Text,
                UserId = 2,
                Added = DateTime.Now,
                
            };
            _vm.AddContact(contact);
            MessageBox.Show("Contact created successfully");
            this.Hide();
        }
    }
}

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
using VR2_Klientrakendus.Models;

namespace VR2_Klientrakendus
{
    /// <summary>
    /// Interaction logic for AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        private readonly AddGroupVM _vm;
        public AddGroupWindow()
        {
            InitializeComponent();
            _vm = new AddGroupVM();
        }

        private void BtnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            Group group = new Group()
            {
                GroupName = TxtGroupName.Text,
                Description = TxtGroupDescription.Text,
                Added = DateTime.Now

            };
            _vm.AddGroup(group);
            MessageBox.Show("Group added successfully");
            this.Hide();
        }
    }
}

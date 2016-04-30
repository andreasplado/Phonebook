using System;
using System.Windows;
using System.Windows.Controls;
using VR2_Klientrakendus.Models;
using VR2_Klientrakendus.ViewModels;

namespace VR2_Klientrakendus
{
    /// <summary>
    /// Interaction logic for Konotraat.xaml
    /// </summary>
    public partial class Konotraat : Window
    {
        private MainWindowVM _vm;
        public Konotraat()
        {
            InitializeComponent();
            this.Loaded += Konotraat_Loaded;
        }

        private void Konotraat_Loaded(object sender, RoutedEventArgs e)
        {
            this._vm = new MainWindowVM();
            //this._vm.LoadUser(3);
            //ShowUserInfo();
            this._vm.LoadContacts();
            this._vm.LoadUsers();
            this._vm.LoadGroups();
            this._vm.LoadFavorites();
            this._vm.LoadLogs();
            this._vm.LoadContactTypes();
            this.DataContext = _vm;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            UserProfile userProfile = new UserProfile();
            userProfile.Show();
        }
        private void TxtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TxtSearch_GotFocus;
        }

        private void BtnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            if (TxtGroupDescription.Text.Equals(""))
            {
                ErrorGroupDescription.Visibility = Visibility.Visible;
            }
            if (TxtGroupname.Text.Equals(""))
            {
                ErrorGroupName.Visibility = Visibility.Visible;
            }
            if (!TxtGroupDescription.Text.Equals("") && !TxtGroupname.Text.Equals(""))
            {
                Group group = new Group()
                {
                    GroupName = TxtGroupname.Text,
                    Description = TxtGroupDescription.Text,
                    Added = DateTime.Now
                };
                Log log = new Log()
                {
                    Description = "User added group: " + TxtGroupname.Text,
                    Added = DateTime.Now,
                    UserId = 1
                };
                _vm.AddGroup(group);
                MessageBox.Show("Group added successfully");
                BtnDeleteGroup.IsEnabled = false;
                BtnUpdateGroup.IsEnabled = false;
                ErrorGroupName.Visibility = Visibility.Hidden;
                ErrorGroupDescription.Visibility = Visibility.Hidden;

            }


        }

        private void BtnAddContactType_Click(object sender, RoutedEventArgs e)
        {
            ContactType contactType = new ContactType()
            {
                ContactTypeValue = TxtContactType.Text,
                Added = DateTime.Now,
                ContactId = 8
            };
            Log log = new Log()
            {
                Description = "Admin added contact type: " + TxtContactType.Text,
                Added = DateTime.Now
            };
            this._vm.AddContactType(contactType);
            this._vm.AddLog(log);
            MessageBox.Show("Contact type added successfully");
            BtnDeleteContactType.IsEnabled = false;
            BtnUpdateContactType.IsEnabled = false;

        }

        private void BtnAddContact_Click(object sender, RoutedEventArgs e)
        {
            string userId = ContactTypeComboBox.SelectedValuePath;
            if (TxtContactName.Text.Equals(""))
            {
                ErrorContactNameMissing.Visibility = Visibility.Visible;
            }
            if (TxtContactLastname.Text.Equals(""))
            {
                ErrorContactLastnameMissing.Visibility = Visibility.Visible;
            }
            if (TxtContactValue.Text.Equals(""))
            {
                ErrorContactValueMissing.Visibility = Visibility.Visible;
            }
            if (!TxtContactName.Text.Equals("") && !TxtContactLastname.Text.Equals("")
                && !TxtContactValue.Text.Equals(""))
            {
                Contact contact = new Contact()
                {
                    ContactName = TxtContactName.Text,
                    ContactLastName = TxtContactLastname.Text,
                    ContactValue = TxtContactValue.Text,
                    Added = DateTime.Now,
                    UserId = 2

                };
                Log log = new Log()
                {
                    Description = "Added contact " + TxtContactName.Text + " " + TxtContactLastname.Text,
                    Added = DateTime.Now,
                    UserId = 2
                };
                _vm.AddContact(contact);
                _vm.AddLog(log);
                MessageBox.Show("Contact added successfully");
                BtnUpdateContact.IsEnabled = false;
                ErrorContactValueMissing.Visibility = Visibility.Hidden;
                ErrorContactNameMissing.Visibility = Visibility.Hidden;
                ErrorContactLastnameMissing.Visibility = Visibility.Hidden;
            }
        }

        private void LbContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbContacts.SelectedIndex > -1)  //Kui on suurem kui -1, siis on midagi valitud.
            {
                BtnUpdateContact.IsEnabled = true;
                BtnDeleteContact.IsEnabled = true;
                TxtContactName.Text = _vm.Contacts[LbContacts.SelectedIndex].ContactName;
                TxtContactLastname.Text = _vm.Contacts[LbContacts.SelectedIndex].ContactLastName;
                TxtContactValue.Text = _vm.Contacts[LbContacts.SelectedIndex].ContactValue;
            }
            BtnUpdateContact.IsEnabled = true;
            BtnDeleteContact.IsEnabled = true;
        }

        private void LbGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbGroups.SelectedIndex > -1) 
            {
                BtnUpdateGroup.IsEnabled = true;
                BtnDeleteGroup.IsEnabled = true;
                TxtGroupname.Text = _vm.Groups[LbGroups.SelectedIndex].GroupName;
                TxtGroupDescription.Text = _vm.Groups[LbGroups.SelectedIndex].Description;
                return;
            }
            BtnUpdateGroup.IsEnabled = false;
            BtnDeleteGroup.IsEnabled = false;
        }

        private void LbContactTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LbContactTypes.SelectedIndex > -1)
            {
                BtnUpdateContactType.IsEnabled = true;
                BtnDeleteContactType.IsEnabled = true;
                TxtContactType.Text = _vm.ContactTypes[LbContactTypes.SelectedIndex].ContactTypeValue;
                return;
            }
            BtnUpdateContactType.IsEnabled = false;
            BtnDeleteContactType.IsEnabled = false;
        }

        private void BtnUpdateContactType_Click(object sender, RoutedEventArgs e)
        {
            ContactType contactType = new ContactType()
            {
                ContactTypeValue = TxtContactType.Text,
                Updated = DateTime.Now,
                ContactId = _vm.ContactTypes[LbContactTypes.SelectedIndex].ContactId
            };
            //this._vm.Update(contactType, _vm.ContactTypes[LbContactTypes.SelectedIndex].ContactId);
        }

        private void BtnAddToFavorites_Click(object sender, RoutedEventArgs e)
        {
            Favorite favorite = new Favorite()
            {
                UserId = _vm.Users[LbUsers.SelectedIndex].UserId,
                Added = DateTime.Now
            };
            Log log = new Log()
            {
                Description = "User " + _vm.Users[LbUsers.SelectedIndex].UserName + " was added to your favorites",
                Added = DateTime.Now,
                UserId = 2

            };
            this._vm.AddFavorite(favorite);
            this._vm.AddLog(log);
            MessageBox.Show("Favorite added successfully");
            BtnAddToFavorites.IsEnabled = false;
        }

        private void LbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnAddToFavorites.IsEnabled = true;
        }

        private void LbFavorites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnDeleteLog.IsEnabled = true;
        }

        private void BtnUpdateGroup_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnDeleteContactType_Click(object sender, RoutedEventArgs e)
        {
            int contactTypeId = _vm.ContactTypes[LbContactTypes.SelectedIndex].ContactId;
            _vm.DeleteContactType(contactTypeId);
            MessageBox.Show("Contact Type deleted");
        }

        private void BtnDeleteContact_Click(object sender, RoutedEventArgs e)
        {
            this._vm.DeleteContact(_vm.Contacts[LbContacts.SelectedIndex].ContactId);
            MessageBox.Show("Contact successfully deleted");
        }

        private void BtnDeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            _vm.DeleteGroup(_vm.Groups[LbGroups.SelectedIndex].GroupId);
            MessageBox.Show("Group successfully deleted");
        }

        private void BtnUpdateContact_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Updated = DateTime.Now,
                ContactLastName = TxtContactLastname.Text,
                ContactName = TxtContactName.Text,
                ContactValue = TxtContactValue.Text,
                UserId = 2
            };

            _vm.UpdateContact(contact, _vm.Contacts[LbContacts.SelectedIndex].ContactId, LbContacts.SelectedIndex);
            MessageBox.Show("Contact successfully updated");
        }

        private void BtnDeleteLog_Click(object sender, RoutedEventArgs e)
        {
            int logId = _vm.Logs[LbLogs.SelectedIndex].LogId;
            _vm.DeleteLog(logId);
            MessageBox.Show("Logs deleted successfully");
        }
    }
}

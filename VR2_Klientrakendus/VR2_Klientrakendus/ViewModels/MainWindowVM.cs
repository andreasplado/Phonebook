using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VR2_Klientrakendus.Models;
using VR2_Klientrakendus.Service;
using VR2_Klientrakendus.Service.Interfaces;

namespace VR2_Klientrakendus.ViewModels
{
    public class MainWindowVM :INotifyPropertyChanged
    {
        private readonly IGroupService _groupService;
        private readonly IFavoritesService _favoritesService;
        private readonly IContactService _contactService;
        private readonly IUserService _userService;
        private readonly IContactTypeService _contactTypeService;
        private readonly ILogService _logService;
        private ObservableCollection<User> _users;
        private ObservableCollection<Group> _groups;
        private ObservableCollection<ContactType> _contactTypes;
        private ObservableCollection<Log> _logs;
        private ObservableCollection<Favorite> _favorites;
        private ObservableCollection<Contact> _contacts;
        private User _user;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowVM()
        {
            this._user = new User();
            this._users = new ObservableCollection<User>();
            this._contactTypes = new ObservableCollection<ContactType>();
            this._logs = new ObservableCollection<Log>();
            this._groups = new ObservableCollection<Group>();
            this._favorites = new ObservableCollection<Favorite>();
            this._groupService = new GroupService();
            this._favoritesService = new FavoritesService();
            this._contactService = new ContactService();
            this._userService = new UserService();
            this._contactTypeService = new ContactTypeService();
            this._logService = new LogService();
        }

        #region Load things
        public async void LoadUsersByFirstName(string firstname)
        {

            this.Users = await this._userService.GetBySearchQuery(firstname);

        }

        public async void LoadUsersByLastName(string lastname)
        {

            this.Users = await this._userService.GetBySearchQuery(lastname);
        }

        public async void LoadGroupsByName(string name)
        {
            this.Groups = await this._groupService.GetBySearchQuery(name);

        }
        public async void LoadUsers()
        {
            this.Users = await this._userService.GetAll();
        }

        public async void LoadUser(int userId)
        {
            this.User = await this._userService.GetById(userId);
        }

        public async void LoadContacts()
        {
            this.Contacts = await this._contactService.GetAll();
        }

        public async void LoadLogs()
        {
            this.Logs = await this._logService.GetAll();
        }

        public async void LoadGroups()
        {
            this.Groups = await this._groupService.GetAll();
        }

        public async void LoadFavorites()
        {
            this.Favorites = await this._favoritesService.GetAll();

        }
        public async void LoadContactTypes()
        {
            this.ContactTypes = await this._contactTypeService.GetAll();

        }
        #endregion
        #region Add things
        public async void AddGroup(Group group)
        {
            this.Groups.Add(await this._groupService.Add(group));
        }

        public async void AddFavorite(Favorite newFavorite)
        {
            this.Favorites.Add(await this._favoritesService.Add(newFavorite));
        }

        public async void AddContact(Contact newContact)
        {
            this.Contacts.Add(await this._contactService.Add(newContact));
        }

        public async void AddLog(Log newLog)
        {
            this.Logs.Add(await this._logService.Add(newLog));
        }

        public async void AddContactType(ContactType newContactType)
        {
            this.ContactTypes.Add(await this._contactTypeService.Add(newContactType));
        }
        #endregion
        #region Update things
        public async void UpdateContact(Contact newContact, int contactId, int listboxPosition)
        {
            this.Contacts.RemoveAt(listboxPosition);
            Contacts.Add(await this._contactService.Update(newContact, contactId));
        }

        public async void UpdateGroup(Group newGroup, int groupId, int listboxPosition)
        {
            this.Groups.RemoveAt(listboxPosition);
            Groups.Add(await this._groupService.Update(newGroup, groupId));

        }
        #endregion
        #region Delete things
        public async void DeleteContact(int contactId)
        {
            this.Contacts.Remove(await this._contactService.Delete(contactId));
        }

        public async void DeleteGroup(int groupId)
        {
            this.Groups.Remove(await this._groupService.Delete(groupId));
        }

        public async void DeleteContactType(int contactTypeId)
        {
            this.ContactTypes.Remove(await this._contactTypeService.Delete(contactTypeId));
        }

        public async void DeleteLog(int logId)
        {
            this.Logs.Remove(await this._logService.Delete(logId));
        }
        #endregion



        #region Properties

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public User User
        {
            get { return this._user; }
            private set
            {
                _user = value;
                NotifyPropertyChanged("User");
            }
        }


        public ObservableCollection<User> Users
        {
            get { return this._users; }
            private set
            {
                _users = value;
                NotifyPropertyChanged("Users");
            }
        }

        public ObservableCollection<Contact> Contacts
        {
            get { return this._contacts; }
            private set
            {
                _contacts = value;
                NotifyPropertyChanged("Contacts");
            }
        }
        public ObservableCollection<Group> Groups
        {
            get { return _groups; }
            private set
            {
                _groups = value;
                NotifyPropertyChanged("Groups");
            }
        }

        public ObservableCollection<ContactType> ContactTypes
        {
            get { return _contactTypes; }
            private set
            {
                _contactTypes = value;
                NotifyPropertyChanged("ContactTypes");
            }
        }
        public ObservableCollection<Log> Logs
        {
            get { return _logs; }
            private set
            {
                _logs = value;
                NotifyPropertyChanged("Logs");
            }
        }

        public ObservableCollection<Favorite> Favorites
        {
            get { return _favorites; }
            private set
            {
                _favorites = value;
                NotifyPropertyChanged("Favorites");
            }
        }
#endregion
    }
}

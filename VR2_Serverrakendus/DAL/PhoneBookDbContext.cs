using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL
{
    public class PhoneBookDbContext : DbContext, IDbContext
    {
        public PhoneBookDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(
            new DropCreateDatabaseIfModelChanges<PhoneBookDbContext>());
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactInGroup> ContactInGroups { get; set; }

        public DbSet<ContactType> ContactTypes { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Log> Logs { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserInRole> UserInRoles { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}

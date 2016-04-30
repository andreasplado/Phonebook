using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DAL.Interfaces;

namespace DAL
{
    public class UOW : IUOW,IDisposable
    {
        private IDbContext DbContext { get; set; }
        protected IEFRepositoryProvider RepositoryProvider { get; set; }

        public UOW(IEFRepositoryProvider repositoryProvider, IDbContext dbContext)
        {
            DbContext = dbContext;

            repositoryProvider.DbContext = dbContext;
            RepositoryProvider = repositoryProvider;
        }

        // UoW main feature - atomic commit at the end of work
        public void Commit()
        {
            ((DbContext)DbContext).SaveChanges();
        }

        //standard repos
        public IEFRepository<Contact> Contacts { get { return GetStandardRepo<Contact>(); } }
        public IEFRepository<ContactType> ContactTypes { get { return GetStandardRepo<ContactType>(); } }
        public IEFRepository<Favorite> Favorites { get { return GetStandardRepo<Favorite>(); } }
        public IEFRepository<Group> Groups { get { return GetStandardRepo<Group>(); } }
        public IEFRepository<Log> Logs { get { return GetStandardRepo<Log>(); } }
        public IEFRepository<ContactInGroup> ContactInGroups { get { return GetStandardRepo<ContactInGroup>(); } }


        // repo with custom methods
        public IUserRepository Users => GetRepo<IUserRepository>();
        // add it also in EFRepositoryFactories.cs, in method GetCustomFactories
        //public ISomeRepo Something { get { return GetRepo<ISomeRepo>(); } }

        // calling standard EF repo provider
        private IEFRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        // calling custom repo provier
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (DbContext != null)
            {
                ((DbContext)DbContext).Dispose();
            }
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repositories
{
    // this is universal base EF repository implementation, to be included in all other repos
    // covers all basic crud methods, common for all other repos
    public class EFRepository<T> : IEFRepository<T> where T : class
    {

        // the context and the dbset we are working with
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        //Constructor, requires dbContext as dependency
        public EFRepository(IDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            DbContext = dbContext as DbContext;
            //get the dbset from context
            if (DbContext != null) DbSet = DbContext.Set<T>();

            if (DbSet == null)
                throw new ArgumentNullException(nameof(T));
        }

        //public IQueryable<T> All
        //{
        //	get { return DbSet; }
        //}

        public virtual List<T> All => DbSet.ToList();

        //public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        //{
        //	return includeProperties.
        //		Aggregate<Expression<Func<T, object>>, IQueryable<T>>(DbSet,
        //		  (current, includeProperty) => current.Include(includeProperty));
        //	/*
        //	// non linq version
        //	foreach (var includeProperty in includeProperties)
        //	{
        //		query = query.Include(includeProperty);
        //	}
        //	return query;
        //	*/
        //}

        public virtual List<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            return includeProperties.
                Aggregate<Expression<Func<T, object>>, IQueryable<T>>(DbSet,
                    (current, includeProperty) => current.Include(includeProperty)).ToList();
            /*
        	// non linq version
        	foreach (var includeProperty in includeProperties)
        	{
        		query = query.Include(includeProperty);
        	}
        	return query.ToList();
        	*/
        }

        public virtual T GetById(params object[] id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Delete(params object[] id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }



        public virtual EntityKey GetPrimaryKeyInfo(T entity)
        {
            var properties = typeof(DbSet).GetProperties();
            foreach (
                var objectContext in
                    properties.Select(propertyInfo => ((IObjectContextAdapter)DbContext).ObjectContext))
            {
                ObjectStateEntry objectStateEntry;
                if (null != entity && objectContext.ObjectStateManager
                    .TryGetObjectStateEntry(entity, out objectStateEntry))
                {
                    return objectStateEntry.EntityKey;
                }
            }
            return null;
        }

        public virtual string[] GetKeyNames(T entity)
        {
            var objectSet = ((IObjectContextAdapter)DbContext).ObjectContext.CreateObjectSet<T>();
            var keyNames = objectSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
            return keyNames;
        }

        public virtual void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public virtual void Dispose()
        {
            //Nothing to dispose
            //maybe log something?
        }
    }
}

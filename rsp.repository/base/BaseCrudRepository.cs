using System.Collections.Generic;

public abstract class BaseRepository<T, IdType> 
        where T : class, IEntity<IdType>
    {
        protected readonly XXXXXXXXXXX currentDbcontext;

        protected BaseRepository(XXXXXXXXXXXXXX dbContext)
        {
            currentDbcontext = dbContext;
        }

        public ICollection<T> find(Expression<Func<T, bool>> filter = null, DataPagingOptions pagingOptions = null,
            params string[] includes)
        {
            IQueryable<T> queryable = currentDbcontext.Set<T>();
            if (includes.Any()) includes.ToList().ForEach(i => { queryable = queryable.Include(i); });

            if (filter != null) queryable = queryable.Where(filter);

            if (pagingOptions != null && (pagingOptions.PageSize.HasValue ||
                                          pagingOptions.PageSize.GetValueOrDefault() > 0 &&
                                          pagingOptions.PageNumber.GetValueOrDefault() > 0))
                queryable = queryable
                    .Skip(pagingOptions.PageNumber.GetValueOrDefault() * pagingOptions.PageSize.GetValueOrDefault())
                    .Take(pagingOptions.PageSize.GetValueOrDefault());

            return queryable.ToList();
        }


        public T findById(IdType Id)
        {
            return currentDbcontext.Set<T>().FirstOrDefault(e => e.Id.Equals(Id));
        }

        public T Create(T entity)
        {
            currentDbcontext.Set<T>().Add(entity);
            entity.CreatedAt = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now);
            currentDbcontext.SaveChanges();
            return entity;
        }

        public virtual T Update(T entity)
        {
            currentDbcontext.Set<T>().Update(entity);
            entity.UpdatedAt = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now);
            currentDbcontext.Entry(entity).Property(p => p.CreatedAt).IsModified = false;
            currentDbcontext.SaveChanges();
            return entity;
        }

        public void UpdateStatusById(IdType id, bool status)
        {
            var entity = findById(id);
            entity.IsActive = status;
            entity.UpdatedAt = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now);
            currentDbcontext.Set<T>().Update(entity);
            currentDbcontext.SaveChanges();
        }

        public void Delete(T entity)
        {
            currentDbcontext.Set<T>().Remove(entity);
            entity.DeletedAt = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now);
            currentDbcontext.SaveChanges();
        }

        public void DeleteById(IdType Id)
        {
            currentDbcontext.Set<T>().Remove(findById(Id));
            currentDbcontext.SaveChanges();
        }

        public void SoftDelete(IdType Id)
        {
            var item = findById(Id);
            item.IsDeleted = true;
            item.DeletedAt = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now);
            currentDbcontext.Set<T>().Update(item);
            currentDbcontext.SaveChanges();
        }

        public bool Exist(IdType Id)
        {
            return currentDbcontext.Set<T>().Any(e => e.Id.Equals(Id) && !e.IsDeleted);
        }

        public bool Exist(Expression<Func<T,bool>> predicate)
        {
            return currentDbcontext.Set<T>().Where(entity => !entity.IsDeleted).Any(predicate);
        }

        public int GetTotalRecordCount()
        {
            return currentDbcontext.Set<T>().Count(entity => !entity.IsDeleted);
        }
    }
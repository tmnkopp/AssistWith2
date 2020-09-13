using System;
using System.Collections.Generic; 
using System.Linq;
using System.Linq.Expressions;
using System.Web; 
using Microsoft.EntityFrameworkCore;

namespace AssistWith.Data
{
    public partial interface IApplicationDbContext
    { 
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
    
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T GetById(object id);
        IQueryable<T> Table { get; }
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
    public class EfRepository<TEntity> : IRepository<TEntity>
            where TEntity : class, new()
    {

        private readonly ApplicationDbContext _context;
        private DbSet<TEntity> _dbSet;

        public EfRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        private DbSet<TEntity> Entities
        {
            get
            {
                return _dbSet ?? (_dbSet = _context.Set<TEntity>());
            }
        }
        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AsEnumerable<TEntity>();
        }
        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }
        public virtual IQueryable<TEntity> Table
        {
            get { return this.Entities; }
        }
        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
            _context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
            _context.SaveChanges();
        }


    }
}
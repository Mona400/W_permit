using Microsoft.EntityFrameworkCore;
using WorkPermit.DAL.Context;

namespace WorkPermit.DAL.Repo.GenericRepo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepo(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

        }

        public void Delete(T entity)
        {
            var deleteEntity = _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(T entity)
        {
            var updateEntity = _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }


    }
}



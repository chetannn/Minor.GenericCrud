using System.Linq;
using System.Collections.Generic;
using Minor.GenericCRUD.Models;
using System.Data.Entity;

namespace Minor.GenericCRUD.Services
{
    public interface ICrudService<TModel>
        where TModel : class
    {
        List<TModel> GetAll();
        int Insert(TModel model);
        int Update(TModel model);
        int Delete(TModel model);
        TModel GetById(int id);
    }
    public class CrudService<TModel> : ICrudService<TModel>
        where TModel : class
    {
        private AppDbContext _context;

        public CrudService()
        {
            _context = new AppDbContext();
        }
        public int Delete(TModel model)
        {
            _context.Set<TModel>().Remove(model);
            return _context.SaveChanges();
        }

        public List<TModel> GetAll()
        {
            return _context.Set<TModel>().ToList();
        }

        public int Insert(TModel model)
        {
            _context.Set<TModel>().Add(model);
            return _context.SaveChanges();
        }

        public int Update(TModel model)
        {
            _context.Entry(model).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public TModel GetById(int id)
        {
            return _context.Set<TModel>().Find(id);
        }
    }
}
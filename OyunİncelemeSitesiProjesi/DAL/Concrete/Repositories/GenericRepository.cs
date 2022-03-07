using OyunİncelemeSitesiProjesi.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace OyunİncelemeSitesiProjesi.DAL.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        OyunContext c = new OyunContext();

        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }
        public void Ekle(T t)
        {
            var addedEntity=c.Entry(t);
            addedEntity.State = EntityState.Added;  
            //_object.Add(t);
            c.SaveChanges();
        }

        public void Güncelle(T t)
        {
            var updatedEntity = c.Entry(t);
            updatedEntity.State=EntityState.Modified;   
            c.SaveChanges();
        }

        public List<T> Listele()
        {
           
            return _object.ToList();
        }

        public List<T> Listele(Expression<Func<T, bool>> Filtrele)
        {
            return _object.Where(Filtrele).ToList();
        }

        public void Sil(T t)
        {
            var deletedEntity = c.Entry(t);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(t);
            c.SaveChanges();
        }
    }
}
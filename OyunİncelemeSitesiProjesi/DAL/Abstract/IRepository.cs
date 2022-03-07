using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OyunİncelemeSitesiProjesi.DAL.Abstract
{
    public interface IRepository<T>
    {
        List<T> Listele();
        void Ekle(T t);
        void Sil(T t);
        void Güncelle(T t);
        List<T> Listele(Expression<Func<T, bool>> Filtrele);
    }
}

using PersonelProject.ToDo.DataAccess.Concrete.EFC.Contexts;
using PersonelProject.ToDo.DataAccess.InterFaces;
using PersonelProject.ToDo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonelProject.ToDo.DataAccess.Concrete.EFC.Repositories
{
    public class EFCGenericRepository<Tablo> : IGenericBranch<Tablo> where Tablo : class, ITablo, new()
    {
        public List<Tablo> GetirButunu()
        {
            using var context = new ToDoContext();
            return context.Set<Tablo>().ToList();

        }

        public Tablo GetirIdCalisma(int id)
        {
            using var context = new ToDoContext();
            return context.Set<Tablo>().Find(id);
        }

        public void Guncelle(Tablo tablo)
        {
            using var context = new ToDoContext();
            context.Set<Tablo>().Update(tablo);
            context.SaveChanges();
        }

        public void Kaydet(Tablo tablo)
        {
            using var context = new ToDoContext();
            context.Set<Tablo>().Add(tablo);
            context.SaveChanges();
        }

        public void Sil(Tablo tablo)
        {
            using var context = new ToDoContext();
            context.Set<Tablo>().Remove(tablo);
            context.SaveChanges();
        }
    }
}

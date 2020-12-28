using PersonelProject.ToDo.Business.Interfaces;
using PersonelProject.ToDo.DataAccess.Concrete.EFC.Repositories;
using PersonelProject.ToDo.DataAccess.InterFaces;
using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonelProject.ToDo.Business.Concrete
{
    public class UrgencyManager : IUrgencyService
    {
        private readonly IUrgencyBranch _urgencyBranch ;
        public UrgencyManager(IUrgencyBranch urgencyBranch)
        {
            _urgencyBranch = urgencyBranch;
           
        }

        public List<Urgency> GetirButunu()
        {
            return _urgencyBranch.GetirButunu();
        }

        public Urgency GetirIdCalisma(int id)
        {
            return _urgencyBranch.GetirIdCalisma(id);
        }

        public void Guncelle(Urgency tablo)
        {
            _urgencyBranch.Guncelle(tablo);
        }

        public void Kaydet(Urgency tablo)
        {
            _urgencyBranch.Kaydet(tablo);
        }

        public void Sil(Urgency tablo)
        {
            _urgencyBranch.Sil(tablo);
        }
    }
}

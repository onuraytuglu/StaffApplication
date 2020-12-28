using PersonelProject.ToDo.Business.Interfaces;
using PersonelProject.ToDo.DataAccess.Concrete.EFC.Repositories;
using PersonelProject.ToDo.DataAccess.InterFaces;
using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonelProject.ToDo.Business.Concrete
{
    public class MissionManager : IMissionService
    {
        //Bir işi tekrarlamamak için interfacesleri kullanmak daha mantıklı.(bazı durumlar için) 
        private readonly IMissionBranch _missionBranch;

        public MissionManager(IMissionBranch missionBranch)
        {
            _missionBranch = missionBranch;
            
        }

        public List<Mission> BringAllWithTables()
        {
            return _missionBranch.BringAllWithTables();
        }

        public Mission BringReportsWithID(int id)
        {
            return _missionBranch.BringReportsWithID(id);
        }

        public Mission BringUrgencyWithId(int id)
        {
            return _missionBranch.BringUrgencyWithId(id);
        }

        public List<Mission> BringUrgencyWithIncomplete()
        {
            return _missionBranch.BringUrgencyWithIncomplete();
        }

        public List<Mission> BringWithUserId(int userId)
        {
            return _missionBranch.BringWithUserId(userId);
        }

        public List<Mission> GetirButunu()
        {
            return _missionBranch.GetirButunu();
        }

        public Mission GetirIdCalisma(int id)
        {
            return _missionBranch.GetirIdCalisma(id);
        }

        public void Guncelle(Mission tablo)
        {
            _missionBranch.Guncelle(tablo);
        }

        public void Kaydet(Mission tablo)
        {
            _missionBranch.Kaydet(tablo);
        }

        public void Sil(Mission tablo)
        {
            _missionBranch.Sil(tablo);
        }
    }
}

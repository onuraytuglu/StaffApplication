using Microsoft.EntityFrameworkCore;
using PersonelProject.ToDo.DataAccess.Concrete.EFC.Contexts;
using PersonelProject.ToDo.DataAccess.InterFaces;
using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonelProject.ToDo.DataAccess.Concrete.EFC.Repositories
{
    public class EFCMissionRepository : EFCGenericRepository<Mission>, IMissionBranch
    {
        public List<Mission> BringAllWithTables()
        {
            using var context = new ToDoContext();
            return context.Missions.Include(I => I.Urgency).Include(I => I.Reports).Include(I => I.AppUser).Where(I => !I.Ozet)
                .OrderByDescending(I => I.OlusturulmaTarih).ToList();
        }

        public Mission BringUrgencyWithId(int id)
        {
            using var context = new ToDoContext();
            return context.Missions.Include(I => I.Urgency).FirstOrDefault(I =>
            !I.Ozet && I.Id == id);
        }

        public Mission BringReportsWithID(int id)
        {

            using var context = new ToDoContext();
            return context.Missions.Include(I => I.Reports).Include(I=>I.AppUser).Where(I => I.Id == id).FirstOrDefault();
        }

        public List<Mission> BringUrgencyWithIncomplete()
        {
            using var context = new ToDoContext();
            return context.Missions.Include(I => I.Urgency).Where(I =>
            !I.Ozet).OrderByDescending(I => I.OlusturulmaTarih).ToList();
        }

        public List<Mission> BringWithUserId(int userId)
        {
            using var context = new ToDoContext();

            return context.Missions.Where(I => I.AppUserId == userId).ToList();
        }
    }
}

using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonelProject.ToDo.Business.Interfaces
{
    public interface IMissionService:IGenericService<Mission>
    {
        List<Mission> BringUrgencyWithIncomplete();
        List<Mission> BringAllWithTables();
        Mission BringUrgencyWithId(int id);
        List<Mission> BringWithUserId(int userId);
        Mission BringReportsWithID(int id);


    }
}

using PersonelProject.ToDo.Entities.Concrete;
using System.Collections.Generic;

namespace PersonelProject.ToDo.DataAccess.InterFaces
{
    public interface IMissionBranch:IGenericBranch<Mission>
    {
        List<Mission> BringUrgencyWithIncomplete();
        List<Mission> BringAllWithTables();
        Mission BringUrgencyWithId(int id);
        List<Mission> BringWithUserId(int userId);
        Mission BringReportsWithID(int id);
    }
}

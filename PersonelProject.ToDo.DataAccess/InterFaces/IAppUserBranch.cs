using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonelProject.ToDo.DataAccess.InterFaces
{
    public interface IAppUserBranch 
    {
        List<AppUser> BringIsNotAdmmins();
        List<AppUser> BringIsNotAdmmins(out int totalPage ,string SearchWord, int ActivePage = 1);

    }
}

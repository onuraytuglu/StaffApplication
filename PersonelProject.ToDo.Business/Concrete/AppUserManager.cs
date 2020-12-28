using PersonelProject.ToDo.Business.Interfaces;
using PersonelProject.ToDo.DataAccess.InterFaces;
using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonelProject.ToDo.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserBranch _userBranch;
        public AppUserManager(IAppUserBranch userBranch)
        {
            _userBranch = userBranch;
        }
        public List<AppUser> BringIsNotAdmmins()
        {
            return _userBranch.BringIsNotAdmmins();
        }

        public List<AppUser> BringIsNotAdmmins(out int totalPage,string SearchWord, int ActivePage)
        {
            return _userBranch.BringIsNotAdmmins(out totalPage,SearchWord, ActivePage);
        }
    }
}

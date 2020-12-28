using PersonelProject.ToDo.DataAccess.Concrete.EFC.Contexts;
using PersonelProject.ToDo.DataAccess.InterFaces;
using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonelProject.ToDo.DataAccess.Concrete.EFC.Repositories
{
    //select* from AspNetUsers inner join AspNetUserRoles
    //on AspNetUsers.Id=AspNetUserRoles.UserId inner join AspNetRoles
    //on AspNetUserRoles.RoleId= AspNetRoles.Id where AspNetRoles.Name= 'Personel'
    public class EFCAppUserRepository : IAppUserBranch
    {
        public List<AppUser> BringIsNotAdmmins()
        {
            using var context = new ToDoContext();

            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {

                    user = resultUser,
                    userRole = resultUserRole


                }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
                (resultTable, resultRole) => new
                {

                    user = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole
                }).Where(I => I.roles.Name == "Personel").Select(I => new AppUser()
                {

                    Id = I.user.Id,
                    Name = I.user.Name,
                    SurName = I.user.SurName,
                    Picture = I.user.Picture,
                    Email = I.user.Email,
                    UserName = I.user.UserName,

                }).ToList();

        }

        public List<AppUser> BringIsNotAdmmins(out int totalPage, string SearchWord, int ActivePage = 1)
        {


            using var context = new ToDoContext();

            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
            (resultUser, resultUserRole) => new
            {

                user = resultUser,
                userRole = resultUserRole


            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id,
            (resultTable, resultRole) => new
            {

                user = resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole
            }).Where(I => I.roles.Name == "Personel").Select(I => new AppUser()
            {

                Id = I.user.Id,
                Name = I.user.Name,
                SurName = I.user.SurName,
                Picture = I.user.Picture,
                Email = I.user.Email,
                UserName = I.user.UserName,

            });

            totalPage = (int)Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(SearchWord))
            {
                result = result.Where(I => I.Name.ToLower().Contains(SearchWord.ToLower())
                || I.SurName.ToLower().Contains(SearchWord.ToLower()));
                totalPage = (int)Math.Ceiling((double)result.Count() / 3);
            }

            result = result.Skip((ActivePage - 1) * 3).Take(3);
            return result.ToList();

        }


    }



    //class ThreeModel
    //{
    //    public AppUser AppUser { get; set; }

    //    public AppRole AppRole { get; set; }
    //}
}

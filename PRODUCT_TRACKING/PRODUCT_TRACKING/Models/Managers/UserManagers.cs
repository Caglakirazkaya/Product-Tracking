using PRODUCT_TRACKING.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRODUCT_TRACKING.Models.Managers
{
    public class UserManagers
    {
        Context c = new Context();
        public List<User> ActivtyUser()
        {
            List<User> getUser = c.Users.ToList();
            List<User> UserList = (from i in getUser.ToList()
                                                     where i.Activity == false
                                                     select new User
                                                     {
                                                         Activity=i.Activity,
                                                         Id=i.Id,
                                                         Name=i.Name,
                                                         Password=i.Password,
                                                         Surname=i.Surname,
                                                         username=i.username
                                                     }).ToList();
            return UserList;
        }

        public List<User> ListUser()
        {
            List<User> getUser = c.Users.ToList();
            List<User> UserList = (from i in getUser.ToList()
                                   where i.Activity == true
                                   select new User
                                   {
                                       Activity = i.Activity,
                                       Id = i.Id,
                                       Name = i.Name,
                                       Password = i.Password,
                                       Surname = i.Surname,
                                       username = i.username
                                   }).ToList();
            return UserList;
        }

        public void AddAuthority(User users)
        {
            Role newrol = c.Roles.FirstOrDefault(a => a.RoleName == "Authority");            
            if(newrol==null)
            {
                newrol.RoleName = "Authority";
                c.Roles.Add(newrol);
                newrol = c.Roles.FirstOrDefault(a => a.RoleName == "Authority");
            }
            UserRole userRole = new UserRole();
            userRole.UserID = users.Id;
            userRole.RoleID = newrol.Id;
            c.UserRoles.Add(userRole);
            c.SaveChanges();
        }

        public void AddCustomer(User users)
        {
            Role newrol = c.Roles.FirstOrDefault(a => a.RoleName == "Customer");
            if (newrol == null)
            {
                newrol.RoleName = "Customer";
                c.Roles.Add(newrol);
                newrol = c.Roles.FirstOrDefault(a => a.RoleName == "Customer");
            }
            UserRole userRole = new UserRole();
            userRole.UserID = users.Id;
            userRole.RoleID = newrol.Id;
            c.UserRoles.Add(userRole);
            c.SaveChanges();
        }
    }
}
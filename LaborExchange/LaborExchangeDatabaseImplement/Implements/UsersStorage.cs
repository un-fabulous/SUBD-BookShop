using System;
using System.Collections.Generic;
using System.Linq;
using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.Interfaces;
using LaborExchangeBusinessLogic.ViewModels;
using LaborExchangeDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace LaborExchangeDatabaseImplement.Implements
{
    public class UsersStorage : IUsersStorage
    {
        public List<UsersViewModel> GetFullList()
        {
            using (var context = new postgresContext())
            {
                return context.Users.Select(rec => new UsersViewModel
                {
                    Userid = rec.Userid,
                    Login = rec.Login,
                    Password = rec.Password,
                    Email = rec.Email,
                    Registrationdate = rec.Registrationdate
                })
                .ToList();
            }
        }

        public List<UsersViewModel> GetFilteredList(UsersBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Users
                .Select(rec => new UsersViewModel
                {
                    Userid = rec.Userid,
                    Login = rec.Login,
                    Password = rec.Password,
                    Email = rec.Email,
                    Registrationdate = rec.Registrationdate
                })
                .ToList();
            }
        }

        public UsersViewModel GetElement(UsersBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                var user = context.Users
                .FirstOrDefault(rec => rec.Login == model.Login || rec.Userid == model.Userid);
                return user != null ?
                new UsersViewModel
                {
                    Userid = user.Userid,
                    Login = user.Login,
                    Password = user.Password,
                    Email = user.Email,
                    Registrationdate = user.Registrationdate
                } :
                null;
            }
        }

        public void Insert(UsersBindingModel model)
        {
            using (var context = new postgresContext())
            {
                context.Users.Add(CreateModel(model, new Users()));
                context.SaveChanges();
            }
        }

        public void Update(UsersBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var element = context.Users.FirstOrDefault(rec => rec.Userid == model.Userid);
                if (element == null)
                {
                    throw new Exception("Пользователь не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(UsersBindingModel model)
        {
            using (var context = new postgresContext())
            {
                Users element = context.Users.FirstOrDefault(rec => rec.Userid == model.Userid);
                if (element != null)
                {
                    context.Users.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
        }

        private Users CreateModel(UsersBindingModel model, Users user)
        {
            user.Login = model.Login;
            user.Password = model.Password;
            user.Email = model.Email;
            user.Registrationdate = model.Registrationdate;
            return user;
        }
    }
}

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
    public class AuthorsStorage : IAuthorsStorage
    {
    
        public List<AuthorsViewModel> GetFullList()
        {
            using (var context = new postgresContext())
            {
                return context.Authors.Select(rec => new AuthorsViewModel
                {
                    Authorid = rec.Authorid,
                    Surname = rec.Surname,
                    Name = rec.Name,
                    Middlename = rec.Middlename,
                    Rating = rec.Rating
                })
                .ToList();
            }
        }

        public List<AuthorsViewModel> GetFilteredList(AuthorsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Authors.Select(rec => new AuthorsViewModel
                {
                    Authorid = rec.Authorid,
                    Surname = rec.Surname,
                    Name = rec.Name,
                    Middlename = rec.Middlename,
                    Rating = rec.Rating
                })
                .ToList();
            }
        }

        public AuthorsViewModel GetElement(AuthorsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                var authors = context.Authors.FirstOrDefault(rec => rec.Authorid == model.Authorid);
                return authors != null ?
                new AuthorsViewModel
                {
                    Authorid = authors.Authorid,
                    Surname = authors.Surname,
                    Name = authors.Name,
                    Middlename = authors.Middlename,
                    Rating = authors.Rating
                } :
                null;
            }
        }

        public void Insert(AuthorsBindingModel model)
        {
            using (var context = new postgresContext())
            {
                context.Authors.Add(CreateModel(model, new Authors()));
                context.SaveChanges();
            }
        }

        public void Update(AuthorsBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var element = context.Authors.FirstOrDefault(rec => rec.Authorid == model.Authorid);
                if (element == null)
                {
                    throw new Exception("Автор не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(AuthorsBindingModel model)
        {
            using (var context = new postgresContext())
            {
                Authors element = context.Authors.FirstOrDefault(rec => rec.Authorid == model.Authorid);
                if (element != null)
                {
                    context.Authors.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Автор не найден");
                }
            }
        }

        private Authors CreateModel(AuthorsBindingModel model, Authors authors)
        {
            authors.Surname = model.Surname;
            authors.Name = model.Name;
            authors.Middlename = model.Middlename;
            authors.Rating = model.Rating;
            return authors;
        }
    }
}

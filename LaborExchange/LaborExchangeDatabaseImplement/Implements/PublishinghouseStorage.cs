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
    public class PublishinghouseStorage : IPublishinghouseStorage
    {
        public List<PublishinghouseViewModel> GetFullList()
        {
            using (var context = new postgresContext())
            {
                return context.Publishinghouse.Select(rec => new PublishinghouseViewModel
                {
                    Phid = rec.Phid,
                    Name = rec.Name
                })
                .ToList();
            }
        }

        public List<PublishinghouseViewModel> GetFilteredList(PublishinghouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Publishinghouse.Select(rec => new PublishinghouseViewModel
                {
                    Phid = rec.Phid,
                    Name = rec.Name
                })
                .ToList();
            }
        }

        public PublishinghouseViewModel GetElement(PublishinghouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                var publishinghouse = context.Publishinghouse.FirstOrDefault(rec => rec.Name == model.Name|| rec.Phid == model.Phid);
                return publishinghouse != null ?
                new PublishinghouseViewModel
                {
                    Phid = publishinghouse.Phid,
                    Name = publishinghouse.Name
                } :
                null;
            }
        }

        public void Insert(PublishinghouseBindingModel model)
        {
            using (var context = new postgresContext())
            {
                context.Publishinghouse.Add(CreateModel(model, new Publishinghouse()));
                context.SaveChanges();
            }
        }

        public void Update(PublishinghouseBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var element = context.Publishinghouse.FirstOrDefault(rec => rec.Phid == model.Phid);
                if (element == null)
                {
                    throw new Exception("Издательство не найдено");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(PublishinghouseBindingModel model)
        {
            using (var context = new postgresContext())
            {
                Publishinghouse element = context.Publishinghouse.FirstOrDefault(rec => rec.Phid == model.Phid);
                if (element != null)
                {
                    context.Publishinghouse.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Издательство не найдено");
                }
            }
        }

        private Publishinghouse CreateModel(PublishinghouseBindingModel model, Publishinghouse publishinghouse)
        {
            publishinghouse.Name = model.Name;
            return publishinghouse;
        }
    }
}

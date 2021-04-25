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
    public class StatusStorage : IStatusStorage
    {
        public List<StatusViewModel> GetFullList()
        {
            using (var context = new postgresContext())
            {
                return context.Status.Select(rec => new StatusViewModel
                {
                    Statusid = rec.Statusid,
                    State = rec.State
                })
                .ToList();
            }
        }

        public List<StatusViewModel> GetFilteredList(StatusBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Status.Select(rec => new StatusViewModel
                {
                    Statusid = rec.Statusid,
                    State = rec.State
                })
                .ToList();
            }
        }

        public StatusViewModel GetElement(StatusBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                var status = context.Status.FirstOrDefault(rec => rec.Statusid == model.Statusid);
                return status != null ?
                new StatusViewModel
                {
                    Statusid = status.Statusid,
                    State = status.State
                } :
                null;
            }
        }

        public void Insert(StatusBindingModel model)
        {
            using (var context = new postgresContext())
            {
                context.Status.Add(CreateModel(model, new Status()));
                context.SaveChanges();
            }
        }

        public void Update(StatusBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var element = context.Status.FirstOrDefault(rec => rec.Statusid == model.Statusid);
                if (element == null)
                {
                    throw new Exception("Статус не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(StatusBindingModel model)
        {
            using (var context = new postgresContext())
            {
                Status element = context.Status.FirstOrDefault(rec => rec.Statusid == model.Statusid);
                if (element != null)
                {
                    context.Status.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Статус не найден");
                }
            }
        }

        private Status CreateModel(StatusBindingModel model, Status status)
        {
  
            status.State = model.State;
            return status;
        }
    }
}

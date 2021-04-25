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
    public class OrdersStorage : IOrdersStorage
    {
   
        public List<OrdersViewModel> GetFullList()
        {

            using (var context = new postgresContext())
            {
                return context.Orders.Include(rec => rec.User).Include(rec => rec.Status).Select(rec => new OrdersViewModel
                {
                    Orderid = rec.Orderid,
                    Orderdate = rec.Orderdate,
                    Userid = rec.Userid,
                    User = rec.User.Login,
                    Deliveryprice = rec.Deliveryprice,
                    Statusid = rec.Statusid,
                    Status = rec.Status.State
                })
                .ToList();
            }
        }

        public List<OrdersViewModel> GetFilteredList(OrdersBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Orders.Include(rec => rec.User).Include(rec => rec.Status).Select(rec => new OrdersViewModel
                {
                    Orderid = rec.Orderid,
                    Orderdate = rec.Orderdate,
                    Userid = rec.Userid,
                    User = rec.User.Login,
                    Deliveryprice = rec.Deliveryprice,
                    Statusid = rec.Statusid,
                    Status = rec.Status.State
                })
                .ToList();
            }
        }

        public OrdersViewModel GetElement(OrdersBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
      
                var orders = context.Orders.Include(rec => rec.User).Include(rec => rec.Status).FirstOrDefault(rec => rec.Orderid == model.Orderid);
                return orders != null ?
                new OrdersViewModel
                {
                    Orderid = orders.Orderid,
                    Orderdate = orders.Orderdate,
                    Userid = orders.Userid,
                    User = orders.User.Login,
                    Deliveryprice = orders.Deliveryprice,
                    Statusid = orders.Statusid,
                    Status = orders.Status.State
                } :
                null;
            }
        }

        public void Insert(OrdersBindingModel model)
        {
            using (var context = new postgresContext())
            {
                context.Orders.Add(CreateModel(model, new Orders()));
                context.SaveChanges();
            }
        }

        public void Update(OrdersBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var element = context.Orders.Include(rec => rec.User).Include(rec => rec.Status).FirstOrDefault(rec => rec.Orderid == model.Orderid);
                if (element == null)
                {
                    throw new Exception("Заказ не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(OrdersBindingModel model)
        {
            using (var context = new postgresContext())
            {
                Orders element = context.Orders.Include(rec => rec.User).Include(rec => rec.Status).FirstOrDefault(rec => rec.Orderid == model.Orderid);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Заказ не найден");
                }
            }
        }

        private Orders CreateModel(OrdersBindingModel model, Orders orders)
        {
            orders.Orderdate = model.Orderdate;
            orders.Userid = model.Userid;
            //orders.User = model.User.Login;
            orders.Deliveryprice = model.Deliveryprice;
            orders.Statusid = model.Statusid;
            //orders.Status = model.Status.State;
            return orders;
        }
    }
}

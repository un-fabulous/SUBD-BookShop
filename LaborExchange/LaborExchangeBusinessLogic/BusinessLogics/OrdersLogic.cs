using System;
using System.Collections.Generic;
using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.Interfaces;
using LaborExchangeBusinessLogic.ViewModels;

namespace LaborExchangeBusinessLogic.BusinessLogics
{
    public class OrdersLogic
    {
        private readonly IOrdersStorage _orderStorage;

        public OrdersLogic(IOrdersStorage orderStorage)
        {
            _orderStorage = orderStorage;
        }

        public List<OrdersViewModel> Read(OrdersBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Orderid.HasValue)
            {
                return new List<OrdersViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(OrdersBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrdersBindingModel
            {
                Orderid = model.Orderid
            });
            if (element != null && element.Orderid != model.Orderid)
            {
                throw new Exception("Уже есть такая сделка");
            }
            if (model.Orderid.HasValue)
            {
                _orderStorage.Update(model);
            }
            else
            {
                _orderStorage.Insert(model);
            }
        }

        public void Delete(OrdersBindingModel model)
        {
            var element = _orderStorage.GetElement(new OrdersBindingModel
            {
                Orderid = model.Orderid
            });
            if (element == null)
            {
                throw new Exception("Сделка не найдена");
            }
            _orderStorage.Delete(model);
        }
    }
}

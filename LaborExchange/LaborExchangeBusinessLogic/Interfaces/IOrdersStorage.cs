using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace LaborExchangeBusinessLogic.Interfaces
{
    public interface IOrdersStorage
    {
        List<OrdersViewModel> GetFullList();

        List<OrdersViewModel> GetFilteredList(OrdersBindingModel model);

        OrdersViewModel GetElement(OrdersBindingModel model);

        void Insert(OrdersBindingModel model);

        void Update(OrdersBindingModel model);

        void Delete(OrdersBindingModel model);
    }
}

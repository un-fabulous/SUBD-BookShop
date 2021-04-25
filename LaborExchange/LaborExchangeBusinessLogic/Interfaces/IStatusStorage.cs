using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace LaborExchangeBusinessLogic.Interfaces
{
    public interface IStatusStorage
    {
        List<StatusViewModel> GetFullList();

        List<StatusViewModel> GetFilteredList(StatusBindingModel model);

        StatusViewModel GetElement(StatusBindingModel model);

        void Insert(StatusBindingModel model);

        void Update(StatusBindingModel model);

        void Delete(StatusBindingModel model);
    }
}

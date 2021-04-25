using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace LaborExchangeBusinessLogic.Interfaces
{
    public interface IPublishinghouseStorage
    {
        List<PublishinghouseViewModel> GetFullList();

        List<PublishinghouseViewModel> GetFilteredList(PublishinghouseBindingModel model);

        PublishinghouseViewModel GetElement(PublishinghouseBindingModel model);

        void Insert(PublishinghouseBindingModel model);

        void Update(PublishinghouseBindingModel model);

        void Delete(PublishinghouseBindingModel model);
    }
}

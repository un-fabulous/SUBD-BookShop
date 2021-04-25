using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace LaborExchangeBusinessLogic.Interfaces
{
    public interface IAuthorsStorage
    {
        List<AuthorsViewModel> GetFullList();

        List<AuthorsViewModel> GetFilteredList(AuthorsBindingModel model);

        AuthorsViewModel GetElement(AuthorsBindingModel model);

        void Insert(AuthorsBindingModel model);

        void Update(AuthorsBindingModel model);

        void Delete(AuthorsBindingModel model);
    }
}

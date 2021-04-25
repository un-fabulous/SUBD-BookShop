using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace LaborExchangeBusinessLogic.Interfaces
{
    public interface IBooksStorage
    {
        List<BooksViewModel> GetFullList();

        List<BooksViewModel> GetFilteredList(BooksBindingModel model);

        BooksViewModel GetElement(BooksBindingModel model);

        void Insert(BooksBindingModel model);

        void Update(BooksBindingModel model);

        void Delete(BooksBindingModel model);
    }
}

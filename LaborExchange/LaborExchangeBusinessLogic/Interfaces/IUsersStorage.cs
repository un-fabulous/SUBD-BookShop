using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace LaborExchangeBusinessLogic.Interfaces
{
    public interface IUsersStorage
    {
        List<UsersViewModel> GetFullList();

        List<UsersViewModel> GetFilteredList(UsersBindingModel model);

        UsersViewModel GetElement(UsersBindingModel model);

        void Insert(UsersBindingModel model);

        void Update(UsersBindingModel model);

        void Delete(UsersBindingModel model);
    }
}

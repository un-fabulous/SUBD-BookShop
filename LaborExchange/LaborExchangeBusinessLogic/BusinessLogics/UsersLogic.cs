using System;
using System.Collections.Generic;
using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.Interfaces;
using LaborExchangeBusinessLogic.ViewModels;

namespace LaborExchangeBusinessLogic.BusinessLogics
{
    public class UsersLogic
    {
        private readonly IUsersStorage _userStorage;

        public UsersLogic(IUsersStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public List<UsersViewModel> Read(UsersBindingModel model)
        {
            if (model == null)
            {
                return _userStorage.GetFullList();
            }
            if (model.Userid.HasValue || model.Login != null)
            {
                return new List<UsersViewModel> { _userStorage.GetElement(model) };
            }
            return _userStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(UsersBindingModel model)
        {
            var element = _userStorage.GetElement(new UsersBindingModel
            {
                Login = model.Login
            });
            if (element != null && element.Userid != model.Userid)
            {
                throw new Exception("Уже есть пользователь с таким логином");
            }
            if (model.Userid.HasValue)
            {
                _userStorage.Update(model);
            }
            else
            {
                _userStorage.Insert(model);
            }
        }

        public void Delete(UsersBindingModel model)
        {
            var element = _userStorage.GetElement(new UsersBindingModel
            {
                Userid = model.Userid
            });
            if (element == null)
            {
                throw new Exception("Пользователь не найден");
            }
            _userStorage.Delete(model);
        }
    }
}

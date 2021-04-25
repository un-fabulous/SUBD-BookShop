using System;
using System.Collections.Generic;
using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.Interfaces;
using LaborExchangeBusinessLogic.ViewModels;

namespace LaborExchangeBusinessLogic.BusinessLogics
{
    public class AuthorsLogic
    {
        private readonly IAuthorsStorage _authorsStorage;

        public AuthorsLogic(IAuthorsStorage authorsStorage)
        {
            _authorsStorage = authorsStorage;
        }

        public List<AuthorsViewModel> Read(AuthorsBindingModel model)
        {
            if (model == null)
            {
                return _authorsStorage.GetFullList();
            }
            if (model.Authorid.HasValue)
            {
                return new List<AuthorsViewModel> { _authorsStorage.GetElement(model) };
            }
            return _authorsStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(AuthorsBindingModel model)
        {
            var element = _authorsStorage.GetElement(new AuthorsBindingModel
            {
                Authorid = model.Authorid
            });
            if (element != null && element.Authorid != model.Authorid)
            {
                throw new Exception("Уже есть такой автор");
            }
            if (model.Authorid.HasValue)
            {
                _authorsStorage.Update(model);
            }
            else
            {
                _authorsStorage.Insert(model);
            }
        }

        public void Delete(AuthorsBindingModel model)
        {
            var element = _authorsStorage.GetElement(new AuthorsBindingModel
            {
                Authorid = model.Authorid
            });
            if (element == null)
            {
                throw new Exception("Автор не найдена");
            }
            _authorsStorage.Delete(model);
        }
    }
}

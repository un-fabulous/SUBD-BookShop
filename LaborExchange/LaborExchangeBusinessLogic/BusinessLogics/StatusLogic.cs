using System;
using System.Collections.Generic;
using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.Interfaces;
using LaborExchangeBusinessLogic.ViewModels;

namespace LaborExchangeBusinessLogic.BusinessLogics
{
    public class StatusLogic
    {
        private readonly IStatusStorage _statusStorage;

        public StatusLogic(IStatusStorage statusStorage)
        {
            _statusStorage = statusStorage;
        }

        public List<StatusViewModel> Read(StatusBindingModel model)
        {
            if (model == null)
            {
                return _statusStorage.GetFullList();
            }
            if (model.Statusid.HasValue)
            {
                return new List<StatusViewModel> { _statusStorage.GetElement(model) };
            }
            return _statusStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(StatusBindingModel model)
        {
            var element = _statusStorage.GetElement(new StatusBindingModel
            {
                Statusid = model.Statusid
            });
            if (element != null && element.Statusid != model.Statusid)
            {
                throw new Exception("Уже есть такой статус");
            }
            if (model.Statusid.HasValue)
            {
                _statusStorage.Update(model);
            }
            else
            {
                _statusStorage.Insert(model);
            }
        }

        public void Delete(StatusBindingModel model)
        {
            var element = _statusStorage.GetElement(new StatusBindingModel
            {
                Statusid = model.Statusid
            });
            if (element == null)
            {
                throw new Exception("Статус не найден");
            }
            _statusStorage.Delete(model);
        }
    }
}

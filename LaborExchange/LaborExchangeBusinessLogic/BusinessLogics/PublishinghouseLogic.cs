using System;
using System.Collections.Generic;
using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.Interfaces;
using LaborExchangeBusinessLogic.ViewModels;

namespace LaborExchangeBusinessLogic.BusinessLogics
{
    public class PublishinghouseLogic
    {
        private readonly IPublishinghouseStorage _publishinghouseStorage;

        public PublishinghouseLogic(IPublishinghouseStorage publishinghouseStorage)
        {
            _publishinghouseStorage = publishinghouseStorage;
        }

        public List<PublishinghouseViewModel> Read(PublishinghouseBindingModel model)
        {
            if (model == null)
            {
                return _publishinghouseStorage.GetFullList();
            }
            if (model.Phid.HasValue)
            {
                return new List<PublishinghouseViewModel> { _publishinghouseStorage.GetElement(model) };
            }
            return _publishinghouseStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PublishinghouseBindingModel model)
        {
            var element = _publishinghouseStorage.GetElement(new PublishinghouseBindingModel
            {
                Phid = model.Phid
            });
            if (element != null && element.Phid != model.Phid)
            {
                throw new Exception("Уже есть такое издательство");
            }
            if (model.Phid.HasValue)
            {
                _publishinghouseStorage.Update(model);
            }
            else
            {
                _publishinghouseStorage.Insert(model);
            }
        }

        public void Delete(PublishinghouseBindingModel model)
        {
            var element = _publishinghouseStorage.GetElement(new PublishinghouseBindingModel
            {
                Phid = model.Phid
            });
            if (element == null)
            {
                throw new Exception("Издательство не найдено");
            }
            _publishinghouseStorage.Delete(model);
        }
    }
}

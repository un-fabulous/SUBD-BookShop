using System;
using System.Collections.Generic;
using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.Interfaces;
using LaborExchangeBusinessLogic.ViewModels;

namespace LaborExchangeBusinessLogic.BusinessLogics
{
    public class BooksLogic
    {
        private readonly IBooksStorage _booksStorage;

        public BooksLogic(IBooksStorage booksStorage)
        {
            _booksStorage = booksStorage;
        }

        public List<BooksViewModel> Read(BooksBindingModel model)
        {
            if (model == null)
            {
                return _booksStorage.GetFullList();
            }
            if (model.Bookid.HasValue)
            {
                return new List<BooksViewModel> { _booksStorage.GetElement(model) };
            }
            return _booksStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(BooksBindingModel model)
        {
            var element = _booksStorage.GetElement(new BooksBindingModel
            {
                Bookid = model.Bookid
            });
            if (element != null && element.Bookid != model.Bookid)
            {
                throw new Exception("Уже есть такая книга");
            }
            if (model.Bookid.HasValue)
            {
                _booksStorage.Update(model);
            }
            else
            {
                _booksStorage.Insert(model);
            }
        }

        public void Delete(BooksBindingModel model)
        {
            var element = _booksStorage.GetElement(new BooksBindingModel
            {
                Bookid = model.Bookid
            });
            if (element == null)
            {
                throw new Exception("Книга не найдена");
            }
            _booksStorage.Delete(model);
        }
    }
}

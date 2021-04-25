using System;
using System.Collections.Generic;
using System.Linq;
using LaborExchangeBusinessLogic.BindingModels;
using LaborExchangeBusinessLogic.Interfaces;
using LaborExchangeBusinessLogic.ViewModels;
using LaborExchangeDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace LaborExchangeDatabaseImplement.Implements
{
    public class BooksStorage : IBooksStorage
    {
        public List<BooksViewModel> GetFullList()
        {
            using (var context = new postgresContext())
            {
                return context.Books.Select(rec => new BooksViewModel
                {
                    Bookid = rec.Bookid,
                    Genre = rec.Genre,
                    Name = rec.Name,
                    Price = rec.Price,
                    Amount = rec.Amount,
                    Rating = rec.Rating
                })
                .ToList();
            }
        }

        public List<BooksViewModel> GetFilteredList(BooksBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                return context.Books.Select(rec => new BooksViewModel
                {
                    Bookid = rec.Bookid,
                    Genre = rec.Genre,
                    Name = rec.Name,
                    Price = rec.Price,
                    Amount = rec.Amount,
                    Rating = rec.Rating
                })
                .ToList();
            }
        }

        public BooksViewModel GetElement(BooksBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new postgresContext())
            {
                var books = context.Books.FirstOrDefault(rec => rec.Bookid == model.Bookid);
                return books != null ?
                new BooksViewModel
                {
                    Bookid = books.Bookid,
                    Genre = books.Genre,
                    Name = books.Name,
                    Price = books.Price,
                    Amount = books.Amount,
                    Rating = books.Rating
                } :
                null;
            }
        }

        public void Insert(BooksBindingModel model)
        {
            using (var context = new postgresContext())
            {
                context.Books.Add(CreateModel(model, new Books()));
                context.SaveChanges();
            }
        }

        public void Update(BooksBindingModel model)
        {
            using (var context = new postgresContext())
            {
                var element = context.Books.FirstOrDefault(rec => rec.Bookid == model.Bookid);
                if (element == null)
                {
                    throw new Exception("Книга не найдена");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(BooksBindingModel model)
        {
            using (var context = new postgresContext())
            {
                Books element = context.Books.FirstOrDefault(rec => rec.Bookid == model.Bookid);
                if (element != null)
                {
                    context.Books.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Книга не найдена");
                }
            }
        }

        private Books CreateModel(BooksBindingModel model, Books books)
        {
            books.Genre = model.Genre;
            books.Name = model.Name;
            books.Price = model.Price;
            books.Amount = model.Amount;
            books.Rating = model.Rating;
            return books;
        }
    }
}

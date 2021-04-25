using System;
using System.Collections.Generic;
using System.Text;

namespace LaborExchangeBusinessLogic.BindingModels
{
    public class BooksBindingModel
    {
        public int? Bookid { get; set; }
        public string Genre { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal? Rating { get; set; }
    }
}

using System;
using System.ComponentModel;

namespace LaborExchangeBusinessLogic.ViewModels
{
    public class BooksViewModel
    {
        public int Bookid { get; set; }


        [DisplayName("Жанр")]
        public string Genre { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DisplayName("Количество")]
        public int Amount { get; set; }

        [DisplayName("Рейтинг")]
        public decimal? Rating { get; set; }


    }
}

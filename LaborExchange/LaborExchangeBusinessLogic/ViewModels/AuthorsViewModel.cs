using System;
using System.ComponentModel;

namespace LaborExchangeBusinessLogic.ViewModels
{
    public class AuthorsViewModel
    {
        public int? Authorid { get; set; }


        [DisplayName("Фамилия")]
        public string Surname { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Отчество")]
        public string Middlename { get; set; }

        [DisplayName("Рейтинг")]
        public decimal? Rating { get; set; }

    }
}

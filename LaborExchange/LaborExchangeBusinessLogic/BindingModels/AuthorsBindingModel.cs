using System;
using System.Collections.Generic;
using System.Text;


namespace LaborExchangeBusinessLogic.BindingModels
{
    public class AuthorsBindingModel
    {
        public int? Authorid { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public decimal? Rating { get; set; }
    }
}

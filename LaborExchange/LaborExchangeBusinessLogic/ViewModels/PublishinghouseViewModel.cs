using System;
using System.ComponentModel;

namespace LaborExchangeBusinessLogic.ViewModels
{
    public class PublishinghouseViewModel
    {
        public int Phid { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

    }
}

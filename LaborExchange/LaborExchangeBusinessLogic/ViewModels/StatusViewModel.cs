using System;
using System.ComponentModel;

namespace LaborExchangeBusinessLogic.ViewModels
{
    public class StatusViewModel
    {

        public int Statusid { get; set; }

        [DisplayName("Состояние")]
        public string State { get; set; }

    }
}

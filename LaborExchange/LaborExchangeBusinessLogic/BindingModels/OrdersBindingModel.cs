using System;
using System.Collections.Generic;
using System.Text;

namespace LaborExchangeBusinessLogic.BindingModels
{
    public class OrdersBindingModel
    {
        public int? Orderid { get; set; }
        public DateTime Orderdate { get; set; }
        public int Userid { get; set; }
        public decimal Deliveryprice { get; set; }
        public int Statusid { get; set; }

    }
}

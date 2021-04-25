using System;
using System.ComponentModel;

namespace LaborExchangeBusinessLogic.ViewModels
{
    public class OrdersViewModel
    {
        public int Orderid { get; set; }


        [DisplayName("Дата заказа")]
        public DateTime Orderdate { get; set; }


        public int Userid { get; set; }

        [DisplayName("Заказчик")]
        public string User { get; set; }

        [DisplayName("Цена доставки")]
        public decimal Deliveryprice { get; set; }

 
        public int Statusid { get; set; }

        [DisplayName("Статус заказа")]
        public string Status { get; set; }
    }
}

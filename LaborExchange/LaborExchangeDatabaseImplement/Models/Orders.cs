using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LaborExchangeDatabaseImplement.Models
{
    public partial class Orders
    {
        public int Orderid { get; set; }
        public DateTime Orderdate { get; set; }
        public int Userid { get; set; }
        public decimal Deliveryprice { get; set; }
        public int Statusid { get; set; }

        public virtual Status Status { get; set; }
        public virtual Users User { get; set; }
    }
}

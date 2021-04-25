﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LaborExchangeDatabaseImplement.Models
{
    public partial class BookOrder
    {
        public int Orderid { get; set; }
        public int Bookid { get; set; }

        public virtual Books Book { get; set; }
        public virtual Orders Order { get; set; }
    }
}
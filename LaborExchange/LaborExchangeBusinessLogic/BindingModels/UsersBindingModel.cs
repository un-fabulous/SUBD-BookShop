using System.Collections.Generic;
using System;

namespace LaborExchangeBusinessLogic.BindingModels
{
    public class UsersBindingModel
    {


        public int? Userid { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? Registrationdate { get; set; }

    }
}

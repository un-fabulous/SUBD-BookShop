using System.ComponentModel;
using System;

namespace LaborExchangeBusinessLogic.ViewModels
{
    public class UsersViewModel
    {
        public int? Userid { get; set; }


        [DisplayName("Логин пользователя")]
        public string Login { get; set; }

        [DisplayName("Пароль пользователя")]
        public string Password { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Дата регистрации")]
        public DateTime? Registrationdate { get; set; }
    }
}

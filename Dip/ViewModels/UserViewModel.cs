using Dip.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.ViewModels
{
    public class UserViewModel
    {
        public User UserInfo { get; set; }
        public IEnumerable<Apiary> Apiaries { get; set; }


        [Display(Name = "Id")]
        public int Id { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Не указано Имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Не указан Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(30, ErrorMessage = "Минимальная длина пароля: 5 символов", MinimumLength = 5)]
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [StringLength(30)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; }
    }
}

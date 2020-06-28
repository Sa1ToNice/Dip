using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.ViewModels
{
    public class ApiaryViewModel
    {
        public IEnumerable<Apiary> Apiaries { get; set; }


        public IEnumerable<Hive> Hives { get; set; }

        public IEnumerable<Event> VEvents { get; set; }

        


        [Display(Name = "Id")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Не указано Название")]
        [StringLength(15, ErrorMessage = "Недопустимая длина")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        
       
        [Display(Name = "Описание")]
        public string Desc { get; set; }

        [Display(Name = "Местоположение")]
        public string Map { get; set; }
    }
}

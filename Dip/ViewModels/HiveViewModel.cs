using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.ViewModels
{
    public class HiveViewModel
    {

        public IEnumerable<Hive> Hives { get; set; }
        [Display(Name = "Id")]
        public int Aid { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано Название")]
        [StringLength(15)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        
        [Display(Name = "Описание")]
        public string Desc { get; set; }


    }
}

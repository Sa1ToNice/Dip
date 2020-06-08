using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.ViewModels
{
    public class EventViewModel
    {
        public IEnumerable<Event> VEvents { get; set; }
        public IEnumerable<Hive> Hives { get; set; }

        [Display(Name = "Id")]
        public int Aid { get; set; }

        [Display(Name = "Id")]
        public int Hid { get; set; }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано Название")]
        [StringLength(22)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан улей")]
        [Display(Name = "Название улья")]
        public string HiveName { get; set; }

        [Required(ErrorMessage = "Не указана дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "Дата события")]
        public DateTime Date { get; set; }


        [Display(Name = "Описание")]
        public string Desc { get; set; }
    }
}

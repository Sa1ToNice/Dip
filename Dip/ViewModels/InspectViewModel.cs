using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.ViewModels
{
    public class InspectViewModel
    {
        public IEnumerable<Inspect> Inspects { get; set; }
        [Display(Name = "Hive name")]
        public string HiveName { get; set; }
        [Display(Name = "Id")]
        public int Aid { get; set; }
        [Display(Name = "Id")]
        public int Hid { get; set; }
        [Display(Name = "Id")]
        public int Id { set; get; }
        [Range(0, 999999999999999, ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Сила семьи")]
        public int Force { set; get; }
        [Range(0, 999999999999999, ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Количество рамок")]
        public int Frame { set; get; }
        [Range(0, 999999999999999, ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Масса улья")]
        public double Mass { set; get; }
        [Required(ErrorMessage = "Не указана дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "Дата изменения")]
        public DateTime Date { get; set; }
        [Display(Name = "Матка")]
        public bool Matka { get; set; }
        [Display(Name = "Дата подсадки")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DatePods { get; set; }
        [Display(Name = "Плодность")]
        public string Plod { get; set; }

    }
}

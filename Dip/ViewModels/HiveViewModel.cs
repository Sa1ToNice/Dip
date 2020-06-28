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
        [StringLength(15, ErrorMessage = "Недопустимая длина")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        
        [Display(Name = "Описание")]
        public string Desc { get; set; }
        [Range(0, 999999999999999, ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Сила семьи")]
        public int Force { set; get; }
        [Range(0, 999999999999999, ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Масса улья")]
        public double Mass { set; get; }
        [Range(0, 999999999999999, ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Количетво рамок")]
        public int Frame { get; set; }
        [Range(0, 999999999999999, ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Ширина рамок")]
        public int Wframe { get; set; }
        [Range(0, 999999999999999, ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Высота рамок")]
        public int Hframe { get; set; }



        [Display(Name = "Порода")]
        public string Porod { get; set; }
        [Display(Name = "Другие отклонения")]
        public string Heal { get; set; }
        [Display(Name = "Акарапидоз")]
        public bool Heal1 { get; set; }
        [Display(Name = "Амебиаз")]
        public bool Heal2 { get; set; }
        [Display(Name = "Американский гнилец")]
        public bool Heal3 { get; set; }
        [Display(Name = "Аскофероз")]
        public bool Heal4 { get; set; }
        [Display(Name = "Аспергиллёз")]
        public bool Heal5 { get; set; }
        [Display(Name = "Варроатоз")]
        public bool Heal6 { get; set; }
        [Display(Name = "Европейский гнилец")]
        public bool Heal7 { get; set; }
        [Display(Name = "Мешотчатый расплод")]
        public bool Heal8 { get; set; }
        [Display(Name = "Нозематоз")]
        public bool Heal9 { get; set; }
        [Display(Name = "Матка")]
        public bool Matka { get; set; }
        [Display(Name = "Дата подсадки")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DatePods { get; set; }
        [Display(Name = "Плодность")]
        public string Plod { get; set; }
        [Display(Name = "Происхождение")]
        public string Prois { get; set; }


    }
}

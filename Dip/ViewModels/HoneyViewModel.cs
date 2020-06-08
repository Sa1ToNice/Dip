﻿using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.ViewModels
{
    public class HoneyViewModel
    {
        public IEnumerable<Honey> Honeys { get; set; }

        [Display(Name = "Hive name")]
        public string HiveName { get; set; }
        [Display(Name = "Id")]
        public int Aid { get; set; }
        [Display(Name = "Id")]
        public int Hid { get; set; }
        [Display(Name = "Id")]
        public int Id { set; get; }
        [Display(Name = "Количество меда")]
        [Required(ErrorMessage = "Не указано количество")]
        public double Get { set; get; }

        [Required(ErrorMessage = "Не указана дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "Дата сбора")]
        public DateTime Date { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Models
{
    public class Apiary
    {
        public int Id { set; get; }

        
        public string Name { set; get; }

        public string Map { set; get; }

        public virtual User User { set; get; }
    }
}

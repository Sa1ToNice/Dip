using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Models
{
    public class Hive
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Desc { set; get; }
        public string Img { set; get; }

        public virtual Apiary Apiary { set; get; }
       
    }
}

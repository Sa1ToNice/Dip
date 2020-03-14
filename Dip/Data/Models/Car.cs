using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Models
{
    public class Car
    {
        public int id { set; get; }
        public string name { set; get; }
        public string desc { set; get; }
        public string img { set; get; }
        public int price { set; get; }
        public bool favorite { get; set; }
        public bool available { get; set; }
        public int categoryId { set; get; }
        public virtual Category Category { set; get; }

    }
}

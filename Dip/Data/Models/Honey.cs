using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Models
{
    public class Honey
    {
        public int Id { set; get; }
        public double Get { set; get; }
        public DateTime Date { get; set; }
        public virtual Hive Hive { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Models
{
    public class Inspect
    {
        public int Id { set; get; }
        public int Force { set; get; }
        public double Mass { set; get; }
        public int Frame { set; get; }
        public DateTime Date { get; set; }
        public bool Matka { get; set; }
        public DateTime DatePods { get; set; }
        public string Plod { get; set; }
        public virtual Hive Hive { set; get; }
    }
}

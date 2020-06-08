using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Models
{
    public class Event
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Desc { set; get; }
       
        public DateTime Date { get; set; }
        
       
        public virtual Hive Hive { set; get; }
    }
}

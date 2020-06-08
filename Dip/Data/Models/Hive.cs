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
        public int Frame { get; set; }
        public int Wframe { get; set; }
        public int Hframe { get; set; }
        public string Porod { get; set; }
        public string Heal { get; set; }
        public bool Heal1 { get; set; }
        public bool Heal2 { get; set; }
        public bool Heal3 { get; set; }
        public bool Heal4 { get; set; }
        public bool Heal5 { get; set; }
        public bool Heal6 { get; set; }
        public bool Heal7 { get; set; }
        public bool Heal8 { get; set; }
        public bool Heal9 { get; set; }

        public bool Matka { get; set; }
        public DateTime DatePods { get; set; }
        public string Plod { get; set; }        
        public string Prois { get; set; }
        
       
       
    }
}

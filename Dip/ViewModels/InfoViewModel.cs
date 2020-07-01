using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.ViewModels
{
    public class InfoViewModel
    {
        public IEnumerable<Info> getInf { get; set; }

        public Info oneInf { get; set; }
        public string[] desc { get; set; }
    }
}

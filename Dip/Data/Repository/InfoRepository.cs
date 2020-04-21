using Dip.Data.Interfaces;
using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Repository
{
    public class InfoRepository : IInfo
    {
        private readonly AppDBContent appDBContent;

        public InfoRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Info> AllInf => appDBContent.Info;
        public IEnumerable<Info> SomeInf (string sea) => appDBContent.Info.Where(p => p.Desc.ToLower().Contains(sea.ToLower()) || p.Name.ToLower().Contains(sea.ToLower()));
        public Info getInfo(string name) => appDBContent.Info.FirstOrDefault(p => p.Name == name);
    }
}

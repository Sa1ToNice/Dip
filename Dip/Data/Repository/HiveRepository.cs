using Dip.Data.Interfaces;
using Dip.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Repository
{
    public class HiveRepository : IHive
    {
        private readonly AppDBContent appDBContent;

        public HiveRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Hive> Hives => appDBContent.Hives.Include(i => i.Apiary);
    }
}

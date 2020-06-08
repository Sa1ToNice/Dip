using Dip.Data.Interfaces;
using Dip.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Repository
{
    public class HoneyRepository : IHoney
    {
        private readonly AppDBContent appDBContent;

        public HoneyRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Honey> Honeys => appDBContent.Honey.Include(i => i.Hive);
    }
}

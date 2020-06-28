using Dip.Data.Interfaces;
using Dip.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Repository
{
    public class InspectRepository : IInspect
    {
        private readonly AppDBContent appDBContent;

        public InspectRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Inspect> Inspects => appDBContent.Inspects.Include(i => i.Hive);
    }
}

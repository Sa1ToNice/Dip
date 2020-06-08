using Dip.Data.Interfaces;
using Dip.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Repository
{
    public class EventRepository : IEvent
    {
        private readonly AppDBContent appDBContent;

        public EventRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Event> Events => appDBContent.Events.Include(i => i.Hive);
    }
}

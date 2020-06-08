using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Interfaces
{
    public interface IEvent
    {
        IEnumerable<Event> Events { get; }
    }
}

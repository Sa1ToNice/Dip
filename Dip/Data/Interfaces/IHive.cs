using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Interfaces
{
    public interface IHive
    {
        IEnumerable<Hive> Hives { get; }
    }
}

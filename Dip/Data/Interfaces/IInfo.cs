using Dip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Interfaces
{
    public interface IInfo
    {
        IEnumerable<Info> AllInf { get; }
        IEnumerable<Info> SomeInf(string sea);
        Info getInfo(string name);
    }
}

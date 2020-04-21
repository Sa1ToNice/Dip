using Dip.Data.Interfaces;
using Dip.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip.Data.Repository
{
    public class ApiaryRepository : IApiary
    {
        private readonly AppDBContent appDBContent;

        public ApiaryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

       
        public IEnumerable<Apiary> Apiaries => appDBContent.Apiaries.Include(c => c.User);

       
        public Apiary GetApId(int id) => appDBContent.Apiaries.FirstOrDefault(p => p.Id == id);

    }
}

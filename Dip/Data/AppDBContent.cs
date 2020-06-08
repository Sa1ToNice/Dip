using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dip.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Dip.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { 
        }


        public DbSet<Info> Info { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Apiary> Apiaries { get; set; }
        public DbSet<Hive> Hives { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Honey> Honey { get; set; }


    }
}

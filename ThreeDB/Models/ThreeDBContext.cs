using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ThreeDB.Models
{
    public class ThreeDBContext : DbContext
    {

        public DbSet<Data> Datas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
            .UseMySql(@"Server=localhost;Port=8889;database=threedb;uid=root;pwd=root;");

        public ThreeDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QC = System.Data.SqlClient;

namespace ThreeDB.Models
{
    public class ThreeDBContext : DbContext
    {

        public DbSet<Data> Datas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
            .UseMySql(@"Server = tcp:threedbserver.database.windows.net, 1433; Initial Catalog = threedb; Persist Security Info=False;User ID = jasunadmin; Password= ThisPasswordIsFor3db; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;");

        public ThreeDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}

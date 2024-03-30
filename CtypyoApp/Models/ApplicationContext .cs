using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtypyoApp.Models
{
    class ApplicationContext:DbContext
    {
        public DbSet<CryptoCurrency> CryptoCoin { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=coin.db");
        }

    }
}

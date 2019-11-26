using Microsoft.EntityFrameworkCore;
using PhoneSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneSite.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Value> MyProperty { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

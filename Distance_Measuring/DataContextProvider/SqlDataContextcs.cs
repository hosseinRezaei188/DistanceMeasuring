using Distance_Measuring.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.DataContextProvider
{
    public class SqlDataContextcs : DbContext
    {
        public SqlDataContextcs(DbContextOptions<SqlDataContextcs> options)
        : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<RequestHistory> RequestHistory { get; set; }

    }
}

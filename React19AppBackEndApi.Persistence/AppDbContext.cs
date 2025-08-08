using Microsoft.EntityFrameworkCore;
using React19AppBackEndApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace React19AppBackEndApi.Persistence
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Activity> Activities { get; set; }
    }
}
 
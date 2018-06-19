using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibleStudyCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BibleStudyCore.Data
{
    public class BibleDbContext   : DbContext
    {
        public BibleDbContext(DbContextOptions<BibleDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
    }
}

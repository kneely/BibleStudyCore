using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibleStudyCore.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Ninject.Planning.Targets;

namespace BibleStudyCore.Data
{
    public abstract class BibleDbContext : DbContext
    {
        protected BibleDbContext(DbContextOptions<BibleDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raffel_Web.Model;

namespace Raffel_Web.Model
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Raffel_Web.Model.Projects> Projects { get; set; }

        public DbSet<Raffel_Web.Model.Scope> Scope { get; set; }

        public DbSet<Raffel_Web.Model.Notes> Notes { get; set; }

        public DbSet<Raffel_Web.Model.Revision> Revision { get; set; }

        public DbSet<Raffel_Web.Model.NetsuiteEntry> NetsuiteEntry { get; set; }
    }
}

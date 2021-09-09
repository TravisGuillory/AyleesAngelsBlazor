using AyleesAngels.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyleesAngels.Server.Data
{
    public class OfficerDbContext : DbContext 
    {
        public OfficerDbContext(DbContextOptions<OfficerDbContext> options) : base(options)
        {

        }
        public DbSet<Officer> Officers { get; set; }
    }
}

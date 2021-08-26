using AyleesAngels.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyleesAngels.Server.Data
{
    public class PartnerDbContext : DbContext
    {   
        public PartnerDbContext(DbContextOptions<PartnerDbContext> options) : base(options)
        {

        }
        public DbSet<Partner> Partners { get; set; }
    }
}



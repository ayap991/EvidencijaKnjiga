using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EvidencijaKnjiga.Models;

namespace EvidencijaKnjiga.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EvidencijaKnjiga.Models.Autor> Autor { get; set; }
        public DbSet<EvidencijaKnjiga.Models.Knjiga> Knjiga { get; set; }
        public DbSet<EvidencijaKnjiga.Models.Status> Status { get; set; }
    }
}

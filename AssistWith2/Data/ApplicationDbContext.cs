using System;
using System.Collections.Generic;
using System.Text;
using AssistWith.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AssistWith.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        } 

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<JobLead> JobLeads { get; set; }
    }
}

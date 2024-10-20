﻿using alte_app.Models;
using Microsoft.EntityFrameworkCore;

namespace alte_app.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EditProfile> EditProfiles { get; set; }
        public DbSet<ProjectCard> Projects { get; set; }
    }
}


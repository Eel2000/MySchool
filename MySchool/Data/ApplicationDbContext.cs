using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySchool.Models;

namespace MySchool.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Parent> Parents { get; set; }

        public DbSet<Enfants> Enfants { get; set; }

        public DbSet<Enseignant> Enseignants { get; set; }

        public DbSet<Cours> Cours { get; set; }

        public DbSet<Travail> Traveaux { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<Punition> Punitions { get; set; }

        public DbSet<Derogation> Derogations { get; set; }

        public DbSet<AssignationCours> AssignationCours { get; set; }


    }
}

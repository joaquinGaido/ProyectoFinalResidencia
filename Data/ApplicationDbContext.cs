using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalResidencia.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalResidencia.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dbResidenciaFinal;Trusted_Connection=True;MultipleActiveResultSets=True");
        }


        public DbSet<Adolecentes> Adolecentes { get; set; }

        public DbSet<Empleados> Empleados { get; set; }

        public DbSet<Familias> Familias { get; set; }

        public DbSet<RamasEspecialidad> RamaEspecialidad { get; set; }

    }
}

using PrzychodniaPOZ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PrzychodniaPOZ.DAL
{
    public class PrzychodniaContext : DbContext
    {
        public PrzychodniaContext()
            : base("PrzychodniaContext")
        {
        }

        static PrzychodniaContext()
        {
            Database.SetInitializer<PrzychodniaContext>(new PrzychodniaInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Badanie> Badanie { get; set; }
        public virtual DbSet<Lekarz> Lekarz { get; set; }
        public virtual DbSet<LekSpec> LekSpec { get; set; }
        public virtual DbSet<Pacjent> Pacjent { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<Specjalizacja> Specjalizacja { get; set; }
        public virtual DbSet<WizytaBadanie> WizytaBadanie { get; set; }
        public virtual DbSet<WizytaLekarz> WizytaLekarz { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas{get;set;}
        public DbSet<Paciente> Pacientes{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)   
     {
         if (!optionBuilder.IsConfigured)
         {
             optionBuilder
             //.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HospiEnCasaData");
             .UseSqlServer("Data Source = localhost; Initial Catalog = HospiEnCasaData; User Id = SA; Password = 2805.GabTT.");
         }
     }
    }
}
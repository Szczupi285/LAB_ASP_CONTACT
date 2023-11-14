using Data.Entities;
using Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }

        public DbSet<ContactEntity> Contacts { get; set; }

        public DbSet<OrganizationEntity> Organizations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(c => c.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>()
                .HasData(
                    new OrganizationEntity()
                    {
                        Id = 1,
                        Name = "WSEI",
                        Description = "Uczelnia wyższa w Krakowie"
                    }
                );

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(o => o.Adress)
                .HasData(
                new
                {
                    OrganizationEntityId = 1,
                    City = "Krakow",
                    Street = "Św. Filipa 17",
                    PostalCode = "31-150"
                }
                );

            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { Id = 1,
                    Name = "Adam", 
                    Email = "adam@wsei.edu.pl", 
                    Phone = "127813268", Birth = new DateTime(2000, 10, 10), 
                    OrganizationId = 1 },

                new ContactEntity() { Id = 2, 
                    Name = "Ewa", 
                    Email = "ewa@wsei.edu.pl", 
                    Phone = "293443823", 
                    Birth = new DateTime(1999, 8, 10), 
                    OrganizationId = 1 }
            );

        }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication8.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<batch> batches { get; set; }
        public virtual DbSet<course> courses { get; set; }
        public virtual DbSet<registation> registations { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<batch>()
                .Property(e => e.batch1)
                .IsUnicode(false);

            modelBuilder.Entity<batch>()
                .Property(e => e.year)
                .IsUnicode(false);

            modelBuilder.Entity<batch>()
                .HasMany(e => e.registations)
                .WithOptional(e => e.batch)
                .HasForeignKey(e => e.batch_id);

            modelBuilder.Entity<course>()
                .Property(e => e.course1)
                .IsUnicode(false);

            modelBuilder.Entity<course>()
                .HasMany(e => e.registations)
                .WithOptional(e => e.course)
                .HasForeignKey(e => e.course_id);

            modelBuilder.Entity<registation>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<registation>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<registation>()
                .Property(e => e.nic)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}

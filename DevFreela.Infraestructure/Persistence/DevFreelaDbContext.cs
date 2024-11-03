using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevFreela.Core.Entities;

namespace DevFreela.Infraestructure.Persistence {

    public class DevFreelaDbContext: DbContext {

        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options) {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            /* 
             * 1. definir as chaves primarias 
             * 2. definir as chaves estrangeiras
             * 
             * 
             * Restrict = Impedir que delete uma entidade que tenha relacionamento com outras
             */
            modelBuilder.Entity<Project>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Freelancer)
                .WithMany(f => f.FreelanceProjects)
                .HasForeignKey(p => p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict); // comportamento quando remover alguma das duas entidades do relacionamento

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)
                .WithMany(f => f.OwnedProjects)
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Skills)
                .WithOne()
                .HasForeignKey(u => u.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Skill>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<UserSkill>()
                .HasKey(us => us.Id);

            modelBuilder.Entity<ProjectComment>()
                .HasKey(pc => pc.Id);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(p => p.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.IdProject);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(p => p.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.IdUser);
        }
    }
}

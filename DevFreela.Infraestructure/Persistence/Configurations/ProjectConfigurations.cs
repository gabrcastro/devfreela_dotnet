﻿using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infraestructure.Persistence.Configurations {
    public class ProjectConfigurations : IEntityTypeConfiguration<Project> {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
           /* 
             * -2. definir as chaves primarias 
             * -1. definir as chaves estrangeiras
             * 
             * 
             * Restrict = Impedir que delete uma entidade que tenha relacionamento com outras
             */
            builder.HasKey(p => p.Id);

            builder.Property(p => p.TotalCost)
                .HasPrecision(18, 2);

            builder.HasOne(p => p.Freelancer)
                .WithMany(f => f.FreelanceProjects)
                .HasForeignKey(p => p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict); // comportamento quando remover alguma das duas entidades do relacionamento

            builder.HasOne(p => p.Client)
                .WithMany(f => f.OwnedProjects)
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

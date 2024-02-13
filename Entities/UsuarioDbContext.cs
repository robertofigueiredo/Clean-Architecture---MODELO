﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clean_Architecture___MODELO.Entities
{
    public partial class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext()
        {
        }

        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
            : base(options)
        {
        }

        #region DB SET

        public virtual DbSet<TabUsuario> TabUsuarios { get; set; } = null!;

        #endregion

        #region CONEXAO BD
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=PC_ROBERTO;Database=master;Trusted_Connection=True;");
            }
        }
        #endregion

        #region CRIAÇÃO MODEL
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabUsuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tab_Usuario");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("CPF");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Telefone).HasMaxLength(9);

                entity.Property(e => e.Usuario).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        #endregion

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

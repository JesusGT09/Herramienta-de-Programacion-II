﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ServicioWedAPI.Models
{
    public partial class BDVENTALIBROSContext : DbContext
    {
        public BDVENTALIBROSContext()
        {
        }

        public BDVENTALIBROSContext(DbContextOptions<BDVENTALIBROSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<CabPedido> CabPedidos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetPedido> DetPedidos { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<LibrosAutore> LibrosAutores { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BDVENTALIBROS;Integrated Security=SSPI; User ID=sa;Password=********;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.HasKey(e => e.CodAutor)
                    .HasName("PK__AUTORES__409926F304297001");

                entity.ToTable("AUTORES");

                entity.Property(e => e.CodAutor)
                    .ValueGeneratedNever()
                    .HasColumnName("COD_AUTOR");

                entity.Property(e => e.CodPais).HasColumnName("COD_PAIS");

                entity.Property(e => e.EmailAutor)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_AUTOR");

                entity.Property(e => e.FecNacAut)
                    .HasColumnType("datetime")
                    .HasColumnName("FEC_NAC_AUT");

                entity.Property(e => e.NomAutor)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NOM_AUTOR");
            });

            modelBuilder.Entity<CabPedido>(entity =>
            {
                entity.HasKey(e => e.NumVta)
                    .HasName("PK__CAB_PEDI__D563B608950CCD52");

                entity.ToTable("CAB_PEDIDO");

                entity.Property(e => e.NumVta)
                    .ValueGeneratedNever()
                    .HasColumnName("NUM_VTA");

                entity.Property(e => e.CodCli)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("COD_CLI")
                    .IsFixedLength(true);

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("TOTAL");

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.CabPedidos)
                    .HasForeignKey(d => d.CodCli)
                    .HasConstraintName("FK__CAB_PEDID__COD_C__2E1BDC42");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCli)
                    .HasName("PK__CLIENTES__151FF48202D84673");

                entity.ToTable("CLIENTES");

                entity.Property(e => e.CodCli)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("COD_CLI")
                    .IsFixedLength(true);

                entity.Property(e => e.CodPais).HasColumnName("COD_PAIS");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.NomCli)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("NOM_CLI");
            });

            modelBuilder.Entity<DetPedido>(entity =>
            {
                entity.HasKey(e => new { e.NumVta, e.CodLibro })
                    .HasName("PK__DET_PEDI__89F45B44BF2C5288");

                entity.ToTable("DET_PEDIDO");

                entity.Property(e => e.NumVta).HasColumnName("NUM_VTA");

                entity.Property(e => e.CodLibro).HasColumnName("COD_LIBRO");

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.Precio)
                    .HasColumnType("money")
                    .HasColumnName("PRECIO");

                entity.HasOne(d => d.NumVtaNavigation)
                    .WithMany(p => p.DetPedidos)
                    .HasForeignKey(d => d.NumVta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DET_PEDID__NUM_V__30F848ED");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.CodLibro)
                    .HasName("PK__LIBROS__C97ED4C407252E6A");

                entity.ToTable("LIBROS");

                entity.Property(e => e.CodLibro)
                    .ValueGeneratedNever()
                    .HasColumnName("COD_LIBRO");

                entity.Property(e => e.Edicion).HasColumnName("EDICION");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.NomLibro)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("NOM_LIBRO");

                entity.Property(e => e.PreLibro)
                    .HasColumnType("money")
                    .HasColumnName("PRE_LIBRO");

                entity.Property(e => e.StkLibro).HasColumnName("STK_LIBRO");
            });

            modelBuilder.Entity<LibrosAutore>(entity =>
            {
                entity.HasKey(e => new { e.CodAutor, e.CodLibro })
                    .HasName("PK__LIBROS_A__1C0ECBBF61B1BB25");

                entity.ToTable("LIBROS_AUTORES");

                entity.Property(e => e.CodAutor).HasColumnName("COD_AUTOR");

                entity.Property(e => e.CodLibro).HasColumnName("COD_LIBRO");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.HasKey(e => e.CodPais)
                    .HasName("PK__PAIS__9FE65885307D3A3A");

                entity.ToTable("PAIS");

                entity.Property(e => e.CodPais)
                    .ValueGeneratedNever()
                    .HasColumnName("COD_PAIS");

                entity.Property(e => e.NomPais)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOM_PAIS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

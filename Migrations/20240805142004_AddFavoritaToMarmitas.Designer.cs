﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitBox.Migrations
{
    [DbContext(typeof(FitDbContext))]
    [Migration("20240805142004_AddFavoritaToMarmitas")]
    partial class AddFavoritaToMarmitas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitBox.Models.Ingrediente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Favorita")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("FitBox.Models.Marmita", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarboidratoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Consumo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataConsumo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Favorita")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProteinaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("TamanhoRecipiente")
                        .HasColumnType("float");

                    b.Property<bool>("Verdura")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CarboidratoId");

                    b.HasIndex("ProteinaId");

                    b.ToTable("Marmitas");
                });

            modelBuilder.Entity("FitBox.Models.MarmitaIngrediente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MarmitaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("MarmitaId");

                    b.ToTable("MarmitaIngrediente");
                });

            modelBuilder.Entity("FitBox.Models.Receitas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarboidratoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Favorita")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProteinaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TamanhoRecipiente")
                        .HasColumnType("int");

                    b.Property<bool>("Verdura")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CarboidratoId");

                    b.HasIndex("ProteinaId");

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("FitBox.Models.Marmita", b =>
                {
                    b.HasOne("FitBox.Models.Ingrediente", "Carboidrato")
                        .WithMany()
                        .HasForeignKey("CarboidratoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FitBox.Models.Ingrediente", "Proteina")
                        .WithMany()
                        .HasForeignKey("ProteinaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Carboidrato");

                    b.Navigation("Proteina");
                });

            modelBuilder.Entity("FitBox.Models.MarmitaIngrediente", b =>
                {
                    b.HasOne("FitBox.Models.Ingrediente", "Ingrediente")
                        .WithMany()
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitBox.Models.Marmita", "Marmita")
                        .WithMany("MarmitasIngredientes")
                        .HasForeignKey("MarmitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Marmita");
                });

            modelBuilder.Entity("FitBox.Models.Receitas", b =>
                {
                    b.HasOne("FitBox.Models.Ingrediente", "Carboidrato")
                        .WithMany()
                        .HasForeignKey("CarboidratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitBox.Models.Ingrediente", "Proteina")
                        .WithMany()
                        .HasForeignKey("ProteinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carboidrato");

                    b.Navigation("Proteina");
                });

            modelBuilder.Entity("FitBox.Models.Marmita", b =>
                {
                    b.Navigation("MarmitasIngredientes");
                });
#pragma warning restore 612, 618
        }
    }
}

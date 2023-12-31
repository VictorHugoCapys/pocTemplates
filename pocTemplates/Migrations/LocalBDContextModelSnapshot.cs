﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pocTemplates;

#nullable disable

namespace pocTemplates.Migrations
{
    [DbContext(typeof(LocalBDContext))]
    partial class LocalBDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("pocTemplates.LocalBDContext+TabelaDeDado", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("altura")
                        .HasColumnType("TEXT");

                    b.Property<int>("idade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nome")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("TabelaDeDados");
                });

            modelBuilder.Entity("pocTemplates.LocalBDContext+TabelaDeDado2", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("idDados")
                        .HasColumnType("INTEGER");

                    b.Property<string>("telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("idDados");

                    b.ToTable("TabelaDeDados2");
                });

            modelBuilder.Entity("pocTemplates.LocalBDContext+VariaveisTemplates", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("identificador")
                        .HasColumnType("TEXT");

                    b.Property<string>("modulo")
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("operacao")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("VariaveisTemplate");
                });

            modelBuilder.Entity("pocTemplates.LocalBDContext+TabelaDeDado2", b =>
                {
                    b.HasOne("pocTemplates.LocalBDContext+TabelaDeDado", "TabelaDeDado")
                        .WithMany()
                        .HasForeignKey("idDados")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TabelaDeDado");
                });
#pragma warning restore 612, 618
        }
    }
}

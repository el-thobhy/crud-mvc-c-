﻿// <auto-generated />
using Aplikasi_Kota.Data_Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aplikasi_Kota.Migrations
{
    [DbContext(typeof(KotaDbContext))]
    [Migration("20240624030821_init-db")]
    partial class initdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aplikasi_Kota.Data_Model.MasterKecamatan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdKota")
                        .HasColumnType("int");

                    b.Property<string>("KodeKecamatan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaKecamatan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdKota");

                    b.ToTable("Kecamatans");
                });

            modelBuilder.Entity("Aplikasi_Kota.Data_Model.MasterKota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KodeKota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamaKota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Master_Kota", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            KodeKota = "DPK",
                            NamaKota = "Depok"
                        },
                        new
                        {
                            Id = 2,
                            KodeKota = "DPK",
                            NamaKota = "Jakarta Utara"
                        },
                        new
                        {
                            Id = 3,
                            KodeKota = "DPK",
                            NamaKota = "Jakarta Selatan"
                        },
                        new
                        {
                            Id = 4,
                            KodeKota = "DPK",
                            NamaKota = "Jakarta Barat"
                        });
                });

            modelBuilder.Entity("Aplikasi_Kota.Data_Model.MasterKecamatan", b =>
                {
                    b.HasOne("Aplikasi_Kota.Data_Model.MasterKota", "Kota")
                        .WithMany()
                        .HasForeignKey("IdKota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kota");
                });
#pragma warning restore 612, 618
        }
    }
}
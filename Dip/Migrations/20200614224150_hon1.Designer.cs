﻿// <auto-generated />
using System;
using Dip.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dip.Migrations
{
    [DbContext(typeof(AppDBContent))]
    [Migration("20200614224150_hon1")]
    partial class hon1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dip.Data.Models.Apiary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Map")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Apiaries");
                });

            modelBuilder.Entity("Dip.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HiveId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HiveId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Dip.Data.Models.Hive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApiaryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePods")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Frame")
                        .HasColumnType("int");

                    b.Property<string>("Heal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Heal1")
                        .HasColumnType("bit");

                    b.Property<bool>("Heal2")
                        .HasColumnType("bit");

                    b.Property<bool>("Heal3")
                        .HasColumnType("bit");

                    b.Property<bool>("Heal4")
                        .HasColumnType("bit");

                    b.Property<bool>("Heal5")
                        .HasColumnType("bit");

                    b.Property<bool>("Heal6")
                        .HasColumnType("bit");

                    b.Property<bool>("Heal7")
                        .HasColumnType("bit");

                    b.Property<bool>("Heal8")
                        .HasColumnType("bit");

                    b.Property<bool>("Heal9")
                        .HasColumnType("bit");

                    b.Property<int>("Hframe")
                        .HasColumnType("int");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Matka")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Porod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prois")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wframe")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApiaryId");

                    b.ToTable("Hives");
                });

            modelBuilder.Entity("Dip.Data.Models.Honey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Get")
                        .HasColumnType("float");

                    b.Property<int?>("HiveId")
                        .HasColumnType("int");

                    b.Property<string>("Prod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HiveId");

                    b.ToTable("Honey");
                });

            modelBuilder.Entity("Dip.Data.Models.Info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Info");
                });

            modelBuilder.Entity("Dip.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dip.Data.Models.Apiary", b =>
                {
                    b.HasOne("Dip.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Dip.Data.Models.Event", b =>
                {
                    b.HasOne("Dip.Data.Models.Hive", "Hive")
                        .WithMany()
                        .HasForeignKey("HiveId");
                });

            modelBuilder.Entity("Dip.Data.Models.Hive", b =>
                {
                    b.HasOne("Dip.Data.Models.Apiary", "Apiary")
                        .WithMany()
                        .HasForeignKey("ApiaryId");
                });

            modelBuilder.Entity("Dip.Data.Models.Honey", b =>
                {
                    b.HasOne("Dip.Data.Models.Hive", "Hive")
                        .WithMany()
                        .HasForeignKey("HiveId");
                });
#pragma warning restore 612, 618
        }
    }
}

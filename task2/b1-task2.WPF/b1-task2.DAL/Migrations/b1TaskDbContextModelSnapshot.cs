﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using b1_task2.DAL.DataDbContext;

#nullable disable

namespace b1_task2.DAL.Migrations
{
    [DbContext(typeof(b1TaskDbContext))]
    partial class b1TaskDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("b1_task2.DAL.Entities.BalanceSheet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BalanceSheets");
                });

            modelBuilder.Entity("b1_task2.DAL.Entities.BankAccountMovement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BalanceSheetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BankAccountNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("OpeningBalanceActive")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OpeningBalancePassive")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TurnoverCredit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TurnoverDebit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("СlosingBalanceActive")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("СlosingBalancePassive")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BalanceSheetId");

                    b.ToTable("BankAccountMovements");
                });

            modelBuilder.Entity("b1_task2.DAL.Entities.ChartOfAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BankAccountNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChartOfAccounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2602ea60-3998-4fd1-b5f1-b65c8ffd5bfb"),
                            BankAccountNumber = 1,
                            Name = "Денежные средства, драгоценные металлы и межбанковские операции",
                            TypeAccount = "-"
                        },
                        new
                        {
                            Id = new Guid("8c8dab8d-0109-4b58-bbb9-7c3c21cd6c37"),
                            BankAccountNumber = 2,
                            Name = "Кредитные и иные активные операции с клиентами",
                            TypeAccount = "-"
                        },
                        new
                        {
                            Id = new Guid("487f86bd-3b8c-4ce9-b701-50a11f9b9d52"),
                            BankAccountNumber = 3,
                            Name = "Счета по операциям клиентов",
                            TypeAccount = "-"
                        },
                        new
                        {
                            Id = new Guid("ef30fddc-531e-4551-b0ed-04fcdb066e12"),
                            BankAccountNumber = 4,
                            Name = "Ценные бумаги",
                            TypeAccount = "-"
                        },
                        new
                        {
                            Id = new Guid("8804bb19-4877-426d-bf14-b570b8f9e1bb"),
                            BankAccountNumber = 5,
                            Name = "Долгосрочные финансовые вложения в уставные фонды юридических лиц, основные средства и прочее имущество",
                            TypeAccount = "-"
                        },
                        new
                        {
                            Id = new Guid("1d8eff1a-d950-4ea1-864d-04f08b7b8505"),
                            BankAccountNumber = 6,
                            Name = "Прочие активы и прочие пассивы",
                            TypeAccount = "-"
                        },
                        new
                        {
                            Id = new Guid("ab1f9624-b264-4d42-a52e-8439d25f23ef"),
                            BankAccountNumber = 7,
                            Name = "Собственный капитал банка",
                            TypeAccount = "-"
                        },
                        new
                        {
                            Id = new Guid("4b1aff57-ec30-4fb3-8b28-c5cb30229a51"),
                            BankAccountNumber = 8,
                            Name = "Доходы банка",
                            TypeAccount = "-"
                        },
                        new
                        {
                            Id = new Guid("19b96b44-af3c-49f3-9426-66e4bbd26608"),
                            BankAccountNumber = 9,
                            Name = "Расходы банка",
                            TypeAccount = "-"
                        });
                });

            modelBuilder.Entity("b1_task2.DAL.Entities.BankAccountMovement", b =>
                {
                    b.HasOne("b1_task2.DAL.Entities.BalanceSheet", null)
                        .WithMany("BankAccountMovements")
                        .HasForeignKey("BalanceSheetId");
                });

            modelBuilder.Entity("b1_task2.DAL.Entities.BalanceSheet", b =>
                {
                    b.Navigation("BankAccountMovements");
                });
#pragma warning restore 612, 618
        }
    }
}

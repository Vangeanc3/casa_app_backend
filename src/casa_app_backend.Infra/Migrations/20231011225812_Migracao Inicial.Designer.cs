﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using casa_app_backend.Infra.Context;

#nullable disable

namespace casa_app_backend.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231011225812_Migracao Inicial")]
    partial class MigracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("casa_app_backend.Domain.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.HouseConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Invite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuestEmail")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("GuestPhone")
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("WorkerType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AssignTask")
                        .HasColumnType("bit");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AssignTask")
                        .HasColumnType("bit");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssignedToId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CanceledDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DoneDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EstimateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("PetId")
                        .HasColumnType("int");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Recurring")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PetId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.ToDoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BaseCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BaseCategoryId");

                    b.ToTable("ToDoCategories");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.ToDoDefault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssignedToId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("PetId")
                        .HasColumnType("int");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.Property<int>("Recurring")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ToDosDefault");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BirthDay")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("ContractId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AssignTask")
                        .HasColumnType("bit");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.HouseConfig", b =>
                {
                    b.HasOne("casa_app_backend.Domain.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Invite", b =>
                {
                    b.HasOne("casa_app_backend.Domain.Models.Contract", "Contract")
                        .WithMany("Invites")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Pet", b =>
                {
                    b.HasOne("casa_app_backend.Domain.Models.HouseConfig", "House")
                        .WithMany("Pets")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Place", b =>
                {
                    b.HasOne("casa_app_backend.Domain.Models.HouseConfig", "House")
                        .WithMany("Places")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.ToDo", b =>
                {
                    b.HasOne("casa_app_backend.Domain.Models.User", "AssignedTo")
                        .WithMany("ToDosAssigned")
                        .HasForeignKey("AssignedToId");

                    b.HasOne("casa_app_backend.Domain.Models.ToDoCategory", "Category")
                        .WithMany("ToDos")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("casa_app_backend.Domain.Models.User", "CreatedBy")
                        .WithMany("ToDosCreated")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("casa_app_backend.Domain.Models.Pet", "Pet")
                        .WithMany("ToDos")
                        .HasForeignKey("PetId");

                    b.HasOne("casa_app_backend.Domain.Models.Place", "Place")
                        .WithMany("ToDos")
                        .HasForeignKey("PlaceId");

                    b.HasOne("casa_app_backend.Domain.Models.Vehicle", "Vehicle")
                        .WithMany("ToDos")
                        .HasForeignKey("VehicleId");

                    b.Navigation("AssignedTo");

                    b.Navigation("Category");

                    b.Navigation("CreatedBy");

                    b.Navigation("Pet");

                    b.Navigation("Place");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.ToDoCategory", b =>
                {
                    b.HasOne("casa_app_backend.Domain.Models.ToDoCategory", "BaseCategory")
                        .WithMany("Categories")
                        .HasForeignKey("BaseCategoryId");

                    b.Navigation("BaseCategory");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.ToDoDefault", b =>
                {
                    b.HasOne("casa_app_backend.Domain.Models.ToDoCategory", "Category")
                        .WithMany("ToDoDefaults")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.User", b =>
                {
                    b.HasOne("casa_app_backend.Domain.Models.Contract", "Contract")
                        .WithMany("UsersOfContract")
                        .HasForeignKey("ContractId");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Vehicle", b =>
                {
                    b.HasOne("casa_app_backend.Domain.Models.HouseConfig", "House")
                        .WithMany("Vehicles")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Worker", b =>
                {
                    b.HasOne("casa_app_backend.Domain.Models.HouseConfig", "House")
                        .WithMany("Workers")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Contract", b =>
                {
                    b.Navigation("Invites");

                    b.Navigation("UsersOfContract");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.HouseConfig", b =>
                {
                    b.Navigation("Pets");

                    b.Navigation("Places");

                    b.Navigation("Vehicles");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Pet", b =>
                {
                    b.Navigation("ToDos");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Place", b =>
                {
                    b.Navigation("ToDos");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.ToDoCategory", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("ToDoDefaults");

                    b.Navigation("ToDos");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.User", b =>
                {
                    b.Navigation("ToDosAssigned");

                    b.Navigation("ToDosCreated");
                });

            modelBuilder.Entity("casa_app_backend.Domain.Models.Vehicle", b =>
                {
                    b.Navigation("ToDos");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Strategy_game.Context;

namespace Strategy_game.Migrations
{
    [DbContext(typeof(ApplitactionDbContext))]
    [Migration("20180720073442_mg11")]
    partial class mg11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Strategy_game.Models.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Builder");

                    b.Property<int>("Counter");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("OwnerCountryCountryId");

                    b.Property<int>("Price");

                    b.HasKey("BuildingId");

                    b.HasIndex("OwnerCountryCountryId");

                    b.ToTable("Buildings");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Building");
                });

            modelBuilder.Entity("Strategy_game.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Alchemy");

                    b.Property<bool>("Combine");

                    b.Property<bool>("Commander");

                    b.Property<string>("CountryName");

                    b.Property<int>("Gold");

                    b.Property<int>("Potatoes");

                    b.Property<bool>("Tactican");

                    b.Property<bool>("Tractor");

                    b.Property<bool>("Wall");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Strategy_game.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoundNumber");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Strategy_game.Models.Platoon", b =>
                {
                    b.Property<int>("PlatoonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArchersUnitId");

                    b.Property<int?>("HorsemansUnitId");

                    b.Property<int?>("OwnerCountryId");

                    b.Property<int?>("SoldiersUnitId");

                    b.HasKey("PlatoonId");

                    b.HasIndex("ArchersUnitId");

                    b.HasIndex("HorsemansUnitId");

                    b.HasIndex("OwnerCountryId");

                    b.HasIndex("SoldiersUnitId");

                    b.ToTable("Platoons");
                });

            modelBuilder.Entity("Strategy_game.Models.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Atk");

                    b.Property<int>("Counter");

                    b.Property<int>("Def");

                    b.Property<bool>("DefenderPosition");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Food");

                    b.Property<int?>("OwnerCountryCountryId");

                    b.Property<int>("Price");

                    b.Property<int>("Salary");

                    b.HasKey("UnitId");

                    b.HasIndex("OwnerCountryCountryId");

                    b.ToTable("Units");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Unit");
                });

            modelBuilder.Entity("Strategy_game.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Gold");

                    b.Property<string>("Name");

                    b.Property<int?>("OwnedCountryCountryId");

                    b.Property<int>("Score");

                    b.HasKey("UserId");

                    b.HasIndex("OwnedCountryCountryId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Strategy_game.Models.Barrack", b =>
                {
                    b.HasBaseType("Strategy_game.Models.Building");

                    b.Property<int>("Capacity");

                    b.ToTable("Barrack");

                    b.HasDiscriminator().HasValue("Barrack");
                });

            modelBuilder.Entity("Strategy_game.Models.Farm", b =>
                {
                    b.HasBaseType("Strategy_game.Models.Building");

                    b.Property<int>("Population");

                    b.Property<int>("PotatoesPerRound");

                    b.ToTable("Farm");

                    b.HasDiscriminator().HasValue("Farm");
                });

            modelBuilder.Entity("Strategy_game.Models.Archer", b =>
                {
                    b.HasBaseType("Strategy_game.Models.Unit");


                    b.ToTable("Archer");

                    b.HasDiscriminator().HasValue("Archer");
                });

            modelBuilder.Entity("Strategy_game.Models.Elite", b =>
                {
                    b.HasBaseType("Strategy_game.Models.Unit");


                    b.ToTable("Elite");

                    b.HasDiscriminator().HasValue("Elite");
                });

            modelBuilder.Entity("Strategy_game.Models.Horseman", b =>
                {
                    b.HasBaseType("Strategy_game.Models.Unit");


                    b.ToTable("Horseman");

                    b.HasDiscriminator().HasValue("Horseman");
                });

            modelBuilder.Entity("Strategy_game.Models.Building", b =>
                {
                    b.HasOne("Strategy_game.Models.Country", "OwnerCountry")
                        .WithMany("Buildings")
                        .HasForeignKey("OwnerCountryCountryId");
                });

            modelBuilder.Entity("Strategy_game.Models.Platoon", b =>
                {
                    b.HasOne("Strategy_game.Models.Archer", "Archers")
                        .WithMany()
                        .HasForeignKey("ArchersUnitId");

                    b.HasOne("Strategy_game.Models.Horseman", "Horsemans")
                        .WithMany()
                        .HasForeignKey("HorsemansUnitId");

                    b.HasOne("Strategy_game.Models.Country", "Owner")
                        .WithMany("Platoons")
                        .HasForeignKey("OwnerCountryId");

                    b.HasOne("Strategy_game.Models.Elite", "Soldiers")
                        .WithMany()
                        .HasForeignKey("SoldiersUnitId");
                });

            modelBuilder.Entity("Strategy_game.Models.Unit", b =>
                {
                    b.HasOne("Strategy_game.Models.Country", "OwnerCountry")
                        .WithMany("Units")
                        .HasForeignKey("OwnerCountryCountryId");
                });

            modelBuilder.Entity("Strategy_game.Models.User", b =>
                {
                    b.HasOne("Strategy_game.Models.Country", "OwnedCountry")
                        .WithMany()
                        .HasForeignKey("OwnedCountryCountryId");
                });
#pragma warning restore 612, 618
        }
    }
}

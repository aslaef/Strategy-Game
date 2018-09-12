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
    [Migration("20180709150014_Initial migration4")]
    partial class Initialmigration4
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

                    b.Property<int?>("CountryId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("BuildingId");

                    b.HasIndex("CountryId");

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

                    b.Property<int?>("OwnerCountryId");

                    b.HasKey("PlatoonId");

                    b.HasIndex("OwnerCountryId");

                    b.ToTable("Platoons");
                });

            modelBuilder.Entity("Strategy_game.Models.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Atk");

                    b.Property<int>("Def");

                    b.Property<bool>("DefenderPosition");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Food");

                    b.Property<int?>("OwnerCountryCountryId");

                    b.Property<int?>("PlatoonTagPlatoonId");

                    b.Property<int>("Price");

                    b.Property<int>("Salary");

                    b.HasKey("UnitId");

                    b.HasIndex("OwnerCountryCountryId");

                    b.HasIndex("PlatoonTagPlatoonId");

                    b.ToTable("Units");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Unit");
                });

            modelBuilder.Entity("Strategy_game.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("Strategy_game.Models.Farm", b =>
                {
                    b.HasBaseType("Strategy_game.Models.Unit");

                    b.Property<int>("Population");

                    b.Property<int>("PotatoesPerRound");

                    b.ToTable("Farm");

                    b.HasDiscriminator().HasValue("Farm");
                });

            modelBuilder.Entity("Strategy_game.Models.Horseman", b =>
                {
                    b.HasBaseType("Strategy_game.Models.Unit");


                    b.ToTable("Horseman");

                    b.HasDiscriminator().HasValue("Horseman");
                });

            modelBuilder.Entity("Strategy_game.Models.Building", b =>
                {
                    b.HasOne("Strategy_game.Models.Country")
                        .WithMany("Buildings")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("Strategy_game.Models.Platoon", b =>
                {
                    b.HasOne("Strategy_game.Models.Country", "Owner")
                        .WithMany("Platoons")
                        .HasForeignKey("OwnerCountryId");
                });

            modelBuilder.Entity("Strategy_game.Models.Unit", b =>
                {
                    b.HasOne("Strategy_game.Models.Country", "OwnerCountry")
                        .WithMany("Units")
                        .HasForeignKey("OwnerCountryCountryId");

                    b.HasOne("Strategy_game.Models.Platoon", "PlatoonTag")
                        .WithMany("Units")
                        .HasForeignKey("PlatoonTagPlatoonId");
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

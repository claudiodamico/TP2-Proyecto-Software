﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP2_REST_AccesData.Data;

#nullable disable

namespace TP2_REST_AccesData.Migrations
{
    [DbContext(typeof(LibreriaDbContext))]
    [Migration("20220430202906_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TP2_REST_Domain.Entities.Alquiler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cliente")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaAlquiler")
                        .HasColumnType("date");

                    b.Property<DateTime?>("FechaDevolucion")
                        .HasColumnType("date");

                    b.Property<DateTime?>("FechaReserva")
                        .HasColumnType("date");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ISBN");

                    b.HasKey("Id");

                    b.HasIndex("Cliente");

                    b.HasIndex("Estado");

                    b.HasIndex("ISBN");

                    b.ToTable("Alquileres");
                });

            modelBuilder.Entity("TP2_REST_Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("DNI");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("TP2_REST_Domain.Entities.EstadoDeAlquiler", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("EstadoId");

                    b.ToTable("EstadoDeAlquileres");

                    b.HasData(
                        new
                        {
                            EstadoId = 1,
                            Descripcion = "Reservado"
                        },
                        new
                        {
                            EstadoId = 2,
                            Descripcion = "Alquilado"
                        },
                        new
                        {
                            EstadoId = 3,
                            Descripcion = "Cancelado"
                        });
                });

            modelBuilder.Entity("TP2_REST_Domain.Entities.Libro", b =>
                {
                    b.Property<string>("ISBN")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ISBN");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Edicion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Editorial")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("ISBN");

                    b.ToTable("Libros");

                    b.HasData(
                        new
                        {
                            ISBN = "9505470673",
                            Autor = "J. R. R. Tolkien",
                            Edicion = "2001",
                            Editorial = "Minotauro ediciones avd",
                            Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/ed/77/ed77b8615c4e99183fa8531a90736da2.jpg",
                            Stock = 15,
                            Titulo = "El Senor de los Anillos I"
                        },
                        new
                        {
                            ISBN = "9788445073735",
                            Autor = "J. R. R. Tolkien",
                            Edicion = "2002",
                            Editorial = "Minotauro ediciones avd",
                            Imagen = "https://images.cdn3.buscalibre.com/fit-in/360x360/ab/57/ab5704b44ae7b4b945e4ab2f92061e74.jpg",
                            Stock = 10,
                            Titulo = "El señor de los anillos II"
                        },
                        new
                        {
                            ISBN = "9788445073742",
                            Autor = "J. R. R. Tolkien",
                            Edicion = "2002",
                            Editorial = "Minotauro ediciones avd",
                            Imagen = "https://images.cdn3.buscalibre.com/fit-in/360x360/6c/c7/6cc7e8d88806fcf50711f82d6187c42e.jpg",
                            Stock = 20,
                            Titulo = "El Señor de los Anillos III"
                        },
                        new
                        {
                            ISBN = "9789877251470",
                            Autor = "George R. R. Martin",
                            Edicion = "2014",
                            Editorial = "Debolsillo",
                            Imagen = "https://images.cdn1.buscalibre.com/fit-in/360x360/3d/76/3d76043985ab3665f9bbbaa4fdf4deaa.jpg",
                            Stock = 10,
                            Titulo = "Juego de Tronos"
                        },
                        new
                        {
                            ISBN = "9786073128841",
                            Autor = "George R. R. Martin",
                            Edicion = "2015",
                            Editorial = "Debolsillo",
                            Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/1d/18/1d18287dbc8c35da55595f045483183f.jpg",
                            Stock = 12,
                            Titulo = "Choque de Reyes"
                        },
                        new
                        {
                            ISBN = "9789563251999",
                            Autor = "George R. R. Martin",
                            Edicion = "2015",
                            Editorial = "Debolsillo",
                            Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/11/84/1184e14aa656b6099a8e88751597515e.jpg",
                            Stock = 18,
                            Titulo = "Tormenta de Espadas"
                        },
                        new
                        {
                            ISBN = "9789563251982",
                            Autor = "George R. R. Martin",
                            Edicion = "2015",
                            Editorial = "Debolsillo",
                            Imagen = "https://images.cdn3.buscalibre.com/fit-in/360x360/2c/fe/2cfea65fe12f59a0d4b20ab05a294953.jpg",
                            Stock = 14,
                            Titulo = "Festin de Cuervos"
                        },
                        new
                        {
                            ISBN = "9789563252033",
                            Autor = "George R. R. Martin",
                            Edicion = "2015",
                            Editorial = "Debolsillo",
                            Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/2e/0f/2e0f16435c40946b5ccf9ea619e833f9.jpg",
                            Stock = 30,
                            Titulo = "Danza de Dragones"
                        },
                        new
                        {
                            ISBN = "9781789092110",
                            Autor = "Tanya Lapointe",
                            Edicion = "2020",
                            Editorial = "Titan Books Ltd",
                            Imagen = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9781/7890/9781789092110.jpg",
                            Stock = 20,
                            Titulo = "Blade Runner 2049"
                        },
                        new
                        {
                            ISBN = "8416543798",
                            Autor = "Shirow Masamune",
                            Edicion = "2017",
                            Editorial = "Planeta Cómic",
                            Imagen = "https://images-na.ssl-images-amazon.com/images/I/51qmqp1+IuL._SX327_BO1,204,203,200_.jpg",
                            Stock = 16,
                            Titulo = "Ghost in the Shell"
                        });
                });

            modelBuilder.Entity("TP2_REST_Domain.Entities.Alquiler", b =>
                {
                    b.HasOne("TP2_REST_Domain.Entities.Cliente", "ClienteNavigation")
                        .WithMany("Alquileres")
                        .HasForeignKey("Cliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP2_REST_Domain.Entities.EstadoDeAlquiler", "EstadoNavigation")
                        .WithMany("Alquileres")
                        .HasForeignKey("Estado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TP2_REST_Domain.Entities.Libro", "IsbnNavigation")
                        .WithMany("Alquileres")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClienteNavigation");

                    b.Navigation("EstadoNavigation");

                    b.Navigation("IsbnNavigation");
                });

            modelBuilder.Entity("TP2_REST_Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Alquileres");
                });

            modelBuilder.Entity("TP2_REST_Domain.Entities.EstadoDeAlquiler", b =>
                {
                    b.Navigation("Alquileres");
                });

            modelBuilder.Entity("TP2_REST_Domain.Entities.Libro", b =>
                {
                    b.Navigation("Alquileres");
                });
#pragma warning restore 612, 618
        }
    }
}
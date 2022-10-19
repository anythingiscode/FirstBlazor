using BlazorCRUDEFCodeFirst.Migrations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorCRUDEFCodeFirst.Models
{
    public class MyBooksContext : DbContext       //Hay que instalar DbContext con el paquete "Microsoft.EntityFrameworkCore"   
    {
        public DbSet<Book> Books { get; set; }     //Representacion de la tabla Books donde estaran todos los books

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PC-ROL;Initial Catalog=BlazorCRUDEFCodeFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }                             
}

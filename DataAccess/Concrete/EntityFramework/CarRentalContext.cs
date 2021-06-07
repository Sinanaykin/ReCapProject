using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class CarRentalContext:DbContext
    {
        //Context: Db tabloları ile proje classlarını bağlamak için yaparız
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Projemin hangi veri tabanıyla ilişkili olduğunu belirrtiğimiz yer(Override yazıp boşluk bırakınca gelir)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-33L0BFJ\SQLEXPRESS;Database=CarRental;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; } //Benim Product nesnemi veritabanındaki Products ile bağla demek buda.
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}

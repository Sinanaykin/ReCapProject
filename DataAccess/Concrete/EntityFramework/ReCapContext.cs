using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class ReCapContext:DbContext
    {
        //Context: Db tabloları ile proje classlarını bağlamak için yaparız
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Projemin hangi veri tabanıyla ilişkili olduğunu belirrtiğimiz yer(Override yazıp boşluk bırakınca gelir)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-33L0BFJ\SQLEXPRESS;Database=ReCap;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; } //Benim Product nesnemi veritabanındaki Products ile bağla demek buda.
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
    }
}

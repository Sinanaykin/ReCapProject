using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        //USİNG BİTTİĞİ ANDA nesneler garbage collector tarafından bellekten atılır.Using c# özel güzel bir yapı(IDisposable pattern implementation of c#).
        {
            using (ReCapContext context = new ReCapContext())
            {
                var addedentity = context.Entry(entity);//contexte bizim göndereceğimiz Car(entity) yakala
                addedentity.State = EntityState.Added;//ilişkilendiidriğimiz yapıyı ekle demek bu
                context.SaveChanges();//değişiklikleri kaydet

            }
        }

        public void Delete(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var deletedentity = context.Entry(entity);//contexte bizim göndereceğimiz Car(entity) yakala
                deletedentity.State = EntityState.Deleted;//ilişkilendiidriğimiz yapıyı sil demek bu
                context.SaveChanges();//değişiklikleri kaydet
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);//contextdeki Car tablomuza yerleştik filtreye göre tek bir ürün getirir
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList(); //Eğer filter null eşitse(filtre vermemişse)  bize tüm tabloyu getir liste yap ,eğer null eşit değilse(filtre vermişse) filtre yap öyle tabloyu getir liste yapıp
                                                                                                                         //context deki Product ta yerleş ve listele :contextdeki Car da yerleş filtrele ve listele
            }
        }

        public void Update(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var updatedentity = context.Entry(entity);//contexte bizim göndereceğimiz car(entity) yakala
                updatedentity.State = EntityState.Modified;//ilişkilendiidriğimiz yapıyı güncelle demek bu
                context.SaveChanges();//değişiklikleri kaydet
            }
        }
    }
}

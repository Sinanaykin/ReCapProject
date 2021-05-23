﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    { 
        
        
            public void Add(TEntity entity)
            //USİNG BİTTİĞİ ANDA nesneler garbage collector tarafından bellekten atılır.Using c# özel güzel bir yapı(IDisposable pattern implementation of c#).
            {
                using (TContext context = new TContext())
                {
                    var addedentity = context.Entry(entity);//contexte bizim göndereceğimiz Car(entity) yakala
                    addedentity.State = EntityState.Added;//ilişkilendiidriğimiz yapıyı ekle demek bu
                    context.SaveChanges();//değişiklikleri kaydet

                }
            }

            public void Delete(TEntity entity)
            {
                using (TContext context = new TContext())
                {
                    var deletedentity = context.Entry(entity);//contexte bizim göndereceğimiz Car(entity) yakala
                    deletedentity.State = EntityState.Deleted;//ilişkilendiidriğimiz yapıyı sil demek bu
                    context.SaveChanges();//değişiklikleri kaydet
                }
            }

            public TEntity Get(Expression<Func<TEntity, bool>> filter)
            {
                using (TContext context = new TContext())
                {
                    return context.Set<TEntity>().SingleOrDefault(filter);//contextdeki Car tablomuza yerleştik filtreye göre tek bir ürün getirir
                }
            }

            public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
            {
                using (TContext context = new TContext())
                {
                    return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList(); //Eğer filter null eşitse(filtre vermemişse)  bize tüm tabloyu getir liste yap ,eğer null eşit değilse(filtre vermişse) filtre yap öyle tabloyu getir liste yapıp
                                                                                                                     //context deki Product ta yerleş ve listele :contextdeki Car da yerleş filtrele ve listele
                }
            }

            public void Update(TEntity entity)
            {
                using (TContext context = new TContext())
                {
                    var updatedentity = context.Entry(entity);//contexte bizim göndereceğimiz car(entity) yakala
                    updatedentity.State = EntityState.Modified;//ilişkilendiidriğimiz yapıyı güncelle demek bu
                    context.SaveChanges();//değişiklikleri kaydet
                }
            }
      }
}

﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfProductDal : IProductDal
    {
        //NuGet: kodların ortak koyulduğu  yer
        public void Add(Product entitiy)
        { 
            //bellekte işi bitince kaldırmak için bu şekilde implemente ettik
            using (NorthwindContext context = new NorthwindContext())
            {
                //referansı yakaldım
                var addedEntitiy = context.Entry(entitiy);
                //aslında bu ekelenecek nesne dedim
                addedEntitiy.State = EntityState.Added;
                //değişiklikleri kaydettim
                context.SaveChanges();
            }
        }

        public void Delete(Product entitiy)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntitiy = context.Entry(entitiy);
                deletedEntitiy.State = EntityState.Deleted;
                context.SaveChanges();
            }
            
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter )
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //filtre null ise db deki bütün productları listele
                //eğer değilse filtreleyip ver filter burada lambda 
                return filter == null
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entitiy)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntitiy = context.Entry(entitiy);
                updatedEntitiy.State = EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}

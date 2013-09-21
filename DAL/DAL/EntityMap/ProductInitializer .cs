using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model;

namespace DAL.EntityMap
{

    public class ProductInitializer : DropCreateDatabaseIfModelChanges<CKGLContext>
    {
        protected override void Seed(CKGLContext context)
        {
            var products = new List<Product> 
                { 
                    new Product { ProductName="产品1",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10}, 
                    new Product { ProductName="产品2",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10 }, 
                    new Product { ProductName="产品3",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10 }, 
                    new Product {   ProductName="产品4",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10 },
                    new Product { ProductName="产品5",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10 },
                    new Product {ProductName="产品6",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10 }, 
                    new Product { ProductName="产品7",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10 }, 
                    new Product { ProductName="产品8",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10 } , 
                    new Product { ProductName="产品9",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10 } , 
                    new Product { ProductName="产品10",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10 } , 
                    new Product { ProductName="产品11",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10 } , 
                    new Product { ProductName="产品12",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10 } , 
                    new Product { ProductName="产品13",LotNum=" Lot1",ProductTime= DateTime.Now,Number=10,CheckTime=DateTime.Now,MaterialNo="料1",UnitNum=10 } , 
                };

            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

        }
    }

}

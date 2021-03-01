using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle,Sql Server, Postgres, MongoDb
            _products = new List<Product> { 
                new Product{ProductId = 1, CatagoryID = 1, ProductName = "Bardak",UnitPrice = 15,UnitInStock=15},
                new Product{ProductId = 2, CatagoryID = 1, ProductName = "Kamera",UnitPrice = 500,UnitInStock=3},
                new Product{ProductId = 3, CatagoryID = 2, ProductName = "Telefon",UnitPrice = 1500,UnitInStock=2},
                new Product{ProductId = 4, CatagoryID = 2, ProductName = "Klavye",UnitPrice = 150,UnitInStock=65},
                new Product{ProductId = 5, CatagoryID = 2, ProductName = "Fare",UnitPrice = 85,UnitInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add( product);
        }

        public void Delete(Product product)
        {
            //LINQ kullanmadan yapımı 

            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);

   //----------------------------------------------------------------

            //LINQ - Language Integreted Query (Dile gomulu sorgulama)
            //=> - Lambda Demek
            Product productToDelete = _products.SingleOrDefault(p=> p.ProductId == product.ProductId);//using System.Linq; ampulden ekşedıkkı SingleORDefault calıssın
            //her bır p ıcıcn(p=>), p nın productıd sı benım gonderdıgım product un productıd sıne esıtse kod calısıyor fore each kısa yolu p=> her p ıcın geızıyor lısteyı
            _products.Remove(productToDelete);

        }

        public List<Product> GetAll()// verı tabanındakı datayı busness a vermem lazım
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
          return _products.Where(p => p.CatagoryID == categoryId).ToList();
            //where yenı bır lıste olusturur senın verdıgın sarta gore

        }

        public void Update(Product product)
        {
            //gönderdiğim urun ıd sıne sahıp olan lıstedekı ürünü bul demek 
            Product productToUpdate = _products.SingleOrDefault(p=> p.ProductId == product.ProductId);//using System.Linq; ampulden ekşedıkkı SingleORDefault calıssın
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CatagoryID = product.CatagoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;

        }
    }
}

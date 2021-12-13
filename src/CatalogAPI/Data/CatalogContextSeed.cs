using CatalogAPI.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CatalogAPI.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if(!existProduct)
            {
                productCollection.InsertManyAsync(GetSampleProducts());

            }
        }
        public static IEnumerable<Product> GetSampleProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "1bac53d2-97ef-4842-b8d2-6ea5a3d36180",
                    Name ="Laptop1",
                    Category = "Laptop",
                    Summary="Laptop Summary1",
                    Description="Laptop1 description",
                    ImageFile ="no -image.jpg",
                    Price = 900.00M
                },
                new Product()
                {
                    Id = "1bac53d2-97ef-4842-b8d2-6ea5a3d36182",
                    Name ="Laptop2",
                    Category = "Laptop2",
                    Summary="Laptop Summary2",
                    Description="Laptop2 description",
                    ImageFile ="no -image2.jpg",
                    Price = 1100.00M
                },
                new Product()
                {
                    Id = "1bac53d2-97ef-4842-b8d2-6ea5a3d36183",
                    Name ="Laptop3",
                    Category = "Laptop3",
                    Summary="Laptop Summary3",
                    Description="Laptop3 description",
                    ImageFile ="no -image3.jpg",
                    Price = 3300.00M
                }
            };
        }
    }
}
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System;
using CatalogAPI.Entities;
using CatalogAPI.Data;

namespace CatalogAPI.Data
{
    public class CatalogContext:ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var mongoclient = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = mongoclient.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
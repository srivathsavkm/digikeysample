using digikey.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace digikey.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Products> _products;

        public ProductService(IDigikeyDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Products>(settings.ProductsCollectionName);
        }

        public List<Products> Get() =>
            _products.Find(book => true).ToList();

        public Products Get(string id) =>
            _products.Find<Products>(p => p.Id == id).FirstOrDefault();

        public Products Create(Products product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string id, Products productIn) =>
            _products.ReplaceOne(p => p.Id == id, productIn);

        public void Remove(Products productIn) =>
            _products.DeleteOne(p => p.Id == productIn.Id);

        public void Remove(string id) =>
            _products.DeleteOne(p => p.Id == id);
    }

}
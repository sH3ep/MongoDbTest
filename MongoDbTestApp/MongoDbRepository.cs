using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqKit;
using MongoDB.Driver;

namespace MongoDbTestApp
{
    public class MongoDbRepository<T> : IMongoDbRepository<T> where T : class,IType
    {
        public IMongoDatabase Database { get; }

        public MongoDbRepository(IMongoClient client)
        {
            Database = client.GetDatabase("mydb");
        }

        public MongoDbRepository(IMongoClient client,string dbName)
        {
            Database = client.GetDatabase(dbName);
        }

        public async Task InsertOne(T model)
        {
            var collectionName = GetCollectionName();
            var collection = Database.GetCollection<T>(collectionName);
            await collection.InsertOneAsync(model);
        }

        public async Task<List<T>> GetCollection()
        {
            var collectionName = GetCollectionName();
            var collection = Database.GetCollection<T>(collectionName);
            return collection.Find(x=>x.Type == typeof(T).Name).ToList();
        }

        public async Task<List<T>> GetCollection(Expression<Func<T,bool>> expression)
        {
            var searchCriteria =  PredicateBuilder.New<T>(true);
            searchCriteria.And(expression);
            searchCriteria.And(x => x.Type == typeof(T).Name);

            var collectionName = GetCollectionName();
            var collection = Database.GetCollection<T>(collectionName);
            
            return collection.Find(searchCriteria).ToList();
        }

        private static string GetCollectionName()
        {
            return (typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()
                as BsonCollectionAttribute).CollectionName;
        }

    }
}
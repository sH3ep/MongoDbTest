using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        private static string GetCollectionName()
        {
            return (typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()
                as BsonCollectionAttribute).CollectionName;
        }

    }
}
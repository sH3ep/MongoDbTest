using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDbTestApp
{
    public class MyMongoDbClient
    {
        public MongoClient MongoClient { get; private set; } 
        public IMongoDatabase Database { get; private set; }

        public MyMongoDbClient(string connectionString)
        {
            MongoClient = new MongoClient(connectionString);
        }

        public MyMongoDbClient()
        {
            MongoClient = new MongoClient("mongodb://localhost:27017");
        }


        public void GetDatabase(string name)
        {
            Database = MongoClient.GetDatabase(name);
        }


    }
}
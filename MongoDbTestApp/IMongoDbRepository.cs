using System.Threading.Tasks;

namespace MongoDbTestApp
{
    public interface IMongoDbRepository<T> where T : class
    {
        Task InsertOne(T model);
    }
}
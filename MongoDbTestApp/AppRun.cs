using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDbTestApp
{
    class AppRun
    {
        public async Task Run()
        {
            Console.WriteLine("Hello World!");

            var mongoDB = new MyMongoDbClient();

            var userRepository = new MongoDbRepository<User>(mongoDB.MongoClient, "TestDB01");
            var user2Repository = new MongoDbRepository<User2>(mongoDB.MongoClient, "TestDB01");

            var users = await userRepository.GetCollection();
            
            var users2 = await user2Repository.GetCollection();


            var userzy = users.Where(x => x.Name == "KArol2").ToList();

            




            //  var user = new User(){Email = "cokolwiek@gmail.com" , Name = "KArol2",Password = "123123123"};

            //  var user2 = new User2() { Email = "cokolwiek@gmail.com", Name = "KArol", Password = "123123123", User = user};

             // await userRepository.InsertOne(user);


            Console.Write("koniec");
            Console.ReadLine();
        }
    }
}

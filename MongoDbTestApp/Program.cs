using System;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Schema;
using MongoDB.Driver;

namespace MongoDbTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new AppRun();

            Task.Run(async () =>await app.Run()).GetAwaiter().GetResult();
           
        }
    }
}

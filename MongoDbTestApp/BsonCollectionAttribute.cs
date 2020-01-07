using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbTestApp
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    class BsonCollectionAttribute : Attribute
    {


        private string _collectionName;
        public BsonCollectionAttribute(string collectionName)
        {
            _collectionName = collectionName;
        }
        public string CollectionName => _collectionName;


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbTestApp
{
    [BsonCollection("Users")]
    class User2:IType
    {
        [BsonId]
        [BsonElement("id")]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("Type")]
        public string Type
        {
            get { return this.GetType().Name; }
        }

        [BsonElement("referee")]
        public User User { get; set; }
    }
}

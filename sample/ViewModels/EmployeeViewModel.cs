using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace sample.ViewModels
{
    public class EmployeeViewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [BsonElement("_id")]
        public ObjectId _id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Gender")]
        public string Gender { get; set; }
        [BsonElement("Position")]

        public string Position { get; set; }

        [BsonElement("DOB")]
        public DateTime DOB { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }
    }
}

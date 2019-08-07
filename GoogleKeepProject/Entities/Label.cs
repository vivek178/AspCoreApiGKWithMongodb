using System;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;


namespace Entities
{
    public class Label
    {
        // properties for label.
        
        [BsonId]
        public int LabelID { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        // for one to many relationship.
        //[JsonIgnore]
    }
}

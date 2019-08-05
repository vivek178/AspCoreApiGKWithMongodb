using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Entities
{
    public class Notes
    {
        // defining properties for Notes.

        [BsonId]
        public int NoteID { get; set; }
        
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }

        // for one to many relationship.
        //[JsonIgnore]
        public ICollection<Label> labels  { get; set; }
    }
}

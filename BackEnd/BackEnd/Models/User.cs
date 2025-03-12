using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace BackEnd.Models
{

    public class User
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }


        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;


        [JsonPropertyName("Password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("Events")]
        public List<Event>? Events { get; set; } = new List<Event>();


    }
}

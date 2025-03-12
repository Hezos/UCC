using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BackEnd.Models
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [JsonPropertyName("UserIds")]
        public List<string> UserIds { get; set; } = new List<string>();

        [JsonPropertyName("Date")]
        public string Date { get; set; } = "";
    }
}

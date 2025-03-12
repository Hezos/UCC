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

        [JsonPropertyName("Title")]
        public string Title { get; set; } = "";

        
        [JsonPropertyName("Date")]
        public string Occurrence { get; set; } = "";

        [JsonPropertyName("Description")]
        public string Description { get; set; } = "";

    }
}

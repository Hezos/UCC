using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UCCbackend2.Models
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [JsonPropertyName("UserId")]
        public string UserId { get; set; } = "";

        [JsonPropertyName("Title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("Occurrence")]
        public string Occurrence { get; set; } = "";

        [JsonPropertyName("Description")]
        public string? Description { get; set; } = "";

        [JsonPropertyName("Datacoder")]
        public int Datacoder { get; set; } = 0;
    }
}

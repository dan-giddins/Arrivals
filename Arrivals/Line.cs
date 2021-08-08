using Newtonsoft.Json;
using System;

namespace Arrivals
{
    public partial class Line
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("modeName")]
        public string ModeName { get; set; }

        [JsonProperty("disruptions")]
        public object[] Disruptions { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("modified")]
        public DateTimeOffset Modified { get; set; }

        [JsonProperty("lineStatuses")]
        public object[] LineStatuses { get; set; }

        [JsonProperty("routeSections")]
        public object[] RouteSections { get; set; }

        [JsonProperty("serviceTypes")]
        public ServiceType[] ServiceTypes { get; set; }

        [JsonProperty("crowding")]
        public Crowding Crowding { get; set; }
    }

    public partial class Crowding
    {
        [JsonProperty("$type")]
        public string Type { get; set; }
    }

    public partial class ServiceType
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public enum Name { Night, Regular };
}

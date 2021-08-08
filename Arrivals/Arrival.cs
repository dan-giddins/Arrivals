using Newtonsoft.Json;
using System;

namespace Arrivals
{
    public partial class Arrival
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("operationType")]
        public long OperationType { get; set; }

        [JsonProperty("vehicleId")]
        public string VehicleId { get; set; }

        [JsonProperty("naptanId")]
        public string NaptanId { get; set; }

        [JsonProperty("stationName")]
        public string StationName { get; set; }

        [JsonProperty("lineId")]
        public string LineId { get; set; }

        [JsonProperty("lineName")]
        public string LineName { get; set; }

        [JsonProperty("platformName")]
        public string PlatformName { get; set; }

        [JsonProperty("bearing")]
        public string Bearing { get; set; }

        [JsonProperty("destinationNaptanId")]
        public string DestinationNaptanId { get; set; }

        [JsonProperty("destinationName")]
        public string DestinationName { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("timeToStation")]
        public long TimeToStation { get; set; }

        [JsonProperty("currentLocation")]
        public string CurrentLocation { get; set; }

        [JsonProperty("towards")]
        public string Towards { get; set; }

        [JsonProperty("expectedArrival")]
        public DateTimeOffset ExpectedArrival { get; set; }

        [JsonProperty("timeToLive")]
        public DateTimeOffset TimeToLive { get; set; }

        [JsonProperty("modeName")]
        public string ModeName { get; set; }

        [JsonProperty("timing")]
        public Timing Timing { get; set; }

        [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
        public Direction? Direction { get; set; }
    }

    public partial class Timing
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("countdownServerAdjustment")]
        public DateTimeOffset CountdownServerAdjustment { get; set; }

        [JsonProperty("source")]
        public DateTimeOffset Source { get; set; }

        [JsonProperty("insert")]
        public DateTimeOffset Insert { get; set; }

        [JsonProperty("read")]
        public DateTimeOffset Read { get; set; }

        [JsonProperty("sent")]
        public DateTimeOffset Sent { get; set; }

        [JsonProperty("received")]
        public DateTimeOffset Received { get; set; }
    }

    public enum Direction { Inbound, Outbound };
}
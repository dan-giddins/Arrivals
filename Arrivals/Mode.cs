using Newtonsoft.Json;

namespace Arrivals
{
    public partial class Mode
    {
        [JsonProperty("$type")]
        public string Type { get; set; }

        [JsonProperty("isTflService")]
        public bool IsTflService { get; set; }

        [JsonProperty("isFarePaying")]
        public bool IsFarePaying { get; set; }

        [JsonProperty("isScheduledService")]
        public bool IsScheduledService { get; set; }

        [JsonProperty("modeName")]
        public string ModeName { get; set; }
    }
}

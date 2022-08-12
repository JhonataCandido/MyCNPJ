using Newtonsoft.Json;
using System;

namespace MyCNPJ.Entities
{
    public class Billing
    {
        public Guid Id { get; set; }

        [JsonProperty("free")]
        public bool Free { get; set; }

        [JsonProperty("database")]
        public bool Database { get; set; }
    }
}

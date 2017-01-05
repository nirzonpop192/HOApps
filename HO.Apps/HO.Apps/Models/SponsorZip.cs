using Newtonsoft.Json;
using System;

namespace HO.Apps.Models
{
    public class SponsorZip
    {
        [JsonProperty("mZipId")]
        public int ZipId { get; set; }

        [JsonProperty("mZipKey")]
        public Guid ZipKey { get; set; }

        [JsonProperty("mZipFile")]
        public string ZipFile { get; set; }
    }
}

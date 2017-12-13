using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PUBGSharp.Data;

namespace PUBGSharp.Net.Model
{
    public class StatsRoot
    {
        [JsonProperty("region")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Region Region { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Mode Mode { get; set; }

        [JsonProperty("stats")]
        public List<StatModel> Stats { get; set; }

        public StatModel KdRatio
        {
            get
            {
                if (Stats == null)
                    return null;
                if (Stats.Count <= 0)
                    return null;
                return Stats[0];
            }
        }
        public StatModel WinPercent
        {
            get
            {
                if (Stats == null)
                    return null;
                if (Stats.Count <= 1)
                    return null;
                return Stats[1];
            }
        }
        public StatModel TimeSurvived
        {
            get
            {
                if (Stats == null)
                    return null;
                if (Stats.Count <= 2)
                    return null;
                return Stats[2];
            }
        }
        public StatModel RoundsPlayed
        {
            get
            {
                if (Stats == null)
                    return null;
                if (Stats.Count <= 3)
                    return null;
                return Stats[3];
            }
        }
    }
}
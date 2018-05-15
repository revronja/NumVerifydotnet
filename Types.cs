
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using NumVerfifydotnet;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace NumVerfifydotnet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Types
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("local_format")]
        public string LocalFormat { get; set; }

        [JsonProperty("international_format")]
        public string InternationalFormat { get; set; }

        [JsonProperty("country_prefix")]
        public string CountryPrefix { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("line_type")]
        public string LineType { get; set; }
    }

    public partial class Types
    {
        public static Types FromJson(string json) => JsonConvert.DeserializeObject<Types>(json, NumVerfifydotnet.Converter.Settings);
    }
    
    public static class Serialize
    {
        public static string ToJson(this Types self) => JsonConvert.SerializeObject(self, NumVerfifydotnet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

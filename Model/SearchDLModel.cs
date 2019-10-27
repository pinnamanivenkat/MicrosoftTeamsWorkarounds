using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamsContactsGroupCreator.Model
{
    public class SearchDLModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public List<SearchResult> Value { get; set; }
    }

    public class SearchResult
    {
        [JsonProperty("mailEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MailEnabled { get; set; }

        [JsonProperty("isUnified", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUnified { get; set; }

        [JsonProperty("isShortProfile")]
        public bool IsShortProfile { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("mail", NullValueHandling = NullValueHandling.Ignore)]
        public string Mail { get; set; }

        [JsonProperty("objectType")]
        public string ObjectType { get; set; }

        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("objectId")]
        public string ObjectId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("securityEnabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SecurityEnabled { get; set; }
    }
}

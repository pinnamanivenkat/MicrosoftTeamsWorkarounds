using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamsContactsGroupCreator.Model
{
    public class DistributionListModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public List<DistributionListUser> DistributionListUsers { get; set; }
    }

    public partial class DistributionListUser
    {
        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("userLocation", NullValueHandling = NullValueHandling.Ignore)]
        public string UserLocation { get; set; }

        [JsonProperty("accountEnabled")]
        public bool AccountEnabled { get; set; }

        [JsonProperty("objectType")]
        public string ObjectType { get; set; }

        [JsonProperty("telephoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string TelephoneNumber { get; set; }

        [JsonProperty("userPrincipalName")]
        public string UserPrincipalName { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("jobTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string JobTitle { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("userType")]
        public string UserType { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("mri")]
        public string Mri { get; set; }

        [JsonProperty("objectId")]
        public string ObjectId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("mobile", NullValueHandling = NullValueHandling.Ignore)]
        public string Mobile { get; set; }
    }
}

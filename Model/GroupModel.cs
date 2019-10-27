using Newtonsoft.Json;
using System.Collections.Generic;

namespace TeamsContactsGroupCreator.Model
{
    public class GroupModel
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("buddies")]
        public List<DistributionListUser> DistributionListUsers { get; set; }
    }
}

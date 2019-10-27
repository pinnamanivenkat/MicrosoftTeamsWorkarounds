using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsContactsGroupCreator.Model
{
    public class CreateGroupResponseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("groupType")]
        public string GroupType { get; set; }

        [JsonProperty("buddies")]
        public List<DistributionListUser> Buddies { get; set; }

        [JsonProperty("eTag")]
        public string ETag { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}

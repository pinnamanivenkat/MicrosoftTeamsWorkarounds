using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsContactsGroupCreator.Model
{
    class AuthorizationFailureResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty("error_codes")]
        public List<long> ErrorCodes { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("trace_id")]
        public Guid TraceId { get; set; }

        [JsonProperty("correlation_id")]
        public Guid CorrelationId { get; set; }
    }
}

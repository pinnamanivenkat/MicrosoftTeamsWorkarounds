﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsContactsGroupCreator.Model
{
    class AuthorizationSuccessResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ExpiresIn { get; set; }

        [JsonProperty("expires_on")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ExpiresOn { get; set; }

        [JsonProperty("resource")]
        public Uri Resource { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("id_token")]
        public string IdToken { get; set; }
    }
}

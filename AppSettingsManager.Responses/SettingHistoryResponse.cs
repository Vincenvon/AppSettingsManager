using System;
using System.Runtime.Serialization;

namespace AppSettingsManager.Responses
{
    [DataContract]
    public class SettingHistoryResponse
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "json")]
        public string Json { get; set; }

        [DataMember(Name = "updatedDateTime")]
        public DateTime UpdatedDateTime { get; set; }
    }
}

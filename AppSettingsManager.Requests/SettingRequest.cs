using System.Runtime.Serialization;

namespace AppSettingsManager.Requests
{
    [DataContract]
    public class SettingRequest
    {
        [DataMember(Name = "json")]
        public string Json { get; set; }
    }
}

using System.Runtime.Serialization;

namespace AppSettingsManager.Responses
{
    [DataContract]
    public class SettingResponse
    {
        [DataMember(Name = "json")]
        public string Json { get; set; }
    }
}

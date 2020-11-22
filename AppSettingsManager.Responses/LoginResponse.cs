using System.Runtime.Serialization;

namespace AppSettingsManager.Responses
{
    [DataContract]
    public class LoginResponse
    {
        [DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }
    }
}

using System.Runtime.Serialization;

namespace AppSettingsManager.Responses
{
    [DataContract]
    public class GridResponse<T>
    {
        [DataMember(Name = "total")]
        public int Total { get; set; }

        [DataMember(Name = "data")]
        public T[] Data { get; set; }
    }
}

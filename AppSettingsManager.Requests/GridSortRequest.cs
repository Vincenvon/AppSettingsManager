using System.Runtime.Serialization;

namespace AppSettingsManager.Requests
{
    [DataContract]
    public class GridSortRequest
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "direction")]
        public string Direction { get; set; }
    }
}

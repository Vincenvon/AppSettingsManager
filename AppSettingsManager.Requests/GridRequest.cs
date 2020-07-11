using System.Runtime.Serialization;

namespace AppSettingsManager.Requests
{
    [DataContract]
    public class GridRequest
    {
        [DataMember(Name = "page")]
        public int Page { get; set; } = 1;

        [DataMember(Name = "pageSize")]
        public int PageSize { get; set; } = 20;

        [DataMember(Name = "filter")]
        public string Filter { get; set; }

        [DataMember(Name = "sort")]
        public GridSortRequest Sort { get; set; }
    }
}

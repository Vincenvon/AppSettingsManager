namespace AppSettingsManager.Requests
{
    public class GridRequest
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public string Filter { get; set; }

        public GridSortRequest Sort { get; set; }
    }
}

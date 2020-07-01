namespace AppSettingsManager.Responses
{
    public class GridResponse<T>
    {
        public int Total { get; set; }

        public T[] Data { get; set; }
    }
}

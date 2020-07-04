using System;

namespace AppSettingsManager.Entities
{
    public class Setting
    {
        public int Id { get; set; }

        public string Json { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}

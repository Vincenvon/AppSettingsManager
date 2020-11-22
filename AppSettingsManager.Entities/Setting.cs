using System;

namespace AppSettingsManager.Entities
{
    public class Setting: Entity
    {
        public string Json { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}

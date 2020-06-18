using System;
using System.Collections.Generic;
using System.Text;

namespace AppSettingsManager.Entity
{
    public class Setting
    {
        public int Id { get; set; }

        public string Json { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}

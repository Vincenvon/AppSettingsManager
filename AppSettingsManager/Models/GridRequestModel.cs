using System;
using System.Collections.Generic;
using System.Text;

namespace AppSettingsManager.Models
{
    public class GridRequestModel
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public string Filter { get; set; }

        public GridSortRequestModel Sort { get; set; }
    }
}

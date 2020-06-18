using System;
using System.Collections.Generic;
using System.Text;

namespace AppSettingsManager.Models
{
    public class GridModel<T>
    {
        public int Total { get; set; }

        public T[] Data { get; set; }
    }
}

using System.Collections.Generic;

namespace Models.Common
{
    public class DataCollection<T>
    {
        public bool HasItems { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
    }
}

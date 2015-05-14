using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamDataGridSample
{
    public class RssEntry
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri Link { get; set; }
        public DateTime PubDate { get; set; }
    }
}

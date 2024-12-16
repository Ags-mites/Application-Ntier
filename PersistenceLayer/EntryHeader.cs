using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer
{
    public class EntryHeader
    {
        public int id { get; set; }
        public DateTime entry_date { get; set; }
        public string voucher_type { get; set; }
        public string numeration { get; set; }
        public string notes { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}

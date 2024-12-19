using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer
{
    public class Logs_EAMS
    {
        public int id { get; set; }
        public string activity_eams { get; set; }
        public DateTime created_at_eams { get; set; }
        public DateTime time_eams { get; set; }
    }
}

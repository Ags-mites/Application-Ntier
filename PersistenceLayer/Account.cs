using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer
{
    public class Account
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int account_type_id { get; set; }
        public string status { get; set; }        
        public DateTime created_at { get; set; }   
        public DateTime updated_at { get; set; }
        
        public AccountType AccountType { get; set; }

    }
}

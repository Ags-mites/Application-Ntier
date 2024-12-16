
namespace PersistenceLayer
{
    public class EntryDetail
    {
        public int id { get; set; }
        public int entry_id { get; set; }
        public int account { get; set; }
        public string description { get; set; }
        public decimal? debit_amount { get; set; }  
        public decimal? credit_amount { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}

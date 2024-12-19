
namespace PersistenceLayer
{
    public class AccountType
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}

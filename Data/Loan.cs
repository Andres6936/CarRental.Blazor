using MySql.Data.Types;

namespace Rental.Data
{
    public class Loan
    {
        public int Serial { get; set; }

        public string User { get; set; }

        public string CarLicense { get; set; }
        
        public MySqlDateTime DateEnd { get; set; }
        
        public MySqlDateTime DateStart { get; set; }
    }
}
using System;

namespace Rental.Data
{
    public class Loan
    {
        public int Serial { get; set; }

        public string User { get; set; }

        public string CarLicense { get; set; }
        
        public string HasBeenCanceled { get; set; }
        
        public DateTime DateEnd { get; set; }
        
        public DateTime DateStart { get; set; }
    }
}
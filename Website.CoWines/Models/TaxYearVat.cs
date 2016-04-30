namespace Website.CoWines.Models
{
    using System;

    public class TaxYearVat
    {
        public int Id { get; set; }
        public DateTime TaxYearStart { get; set; }
        public DateTime TaxYearEnd { get; set; }
        public decimal VatPercent { get; set; }
    }
}

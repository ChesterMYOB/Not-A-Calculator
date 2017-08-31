namespace PayslipConsole.Entities
{
    internal class TaxBracket
    {
        public TaxBracket(double floor, double ceiling, double baseTax, double additionalTaxPerExtraDollar)
        {
            Floor = floor;
            Ceiling = ceiling;         
            BaseTax = baseTax;
            AdditionalTaxPerExtraDollar = additionalTaxPerExtraDollar;
        }

        public double Floor { get; set; }
        public double Ceiling { get; set; }
        public double BaseTax { get; set; }
        public double AdditionalTaxPerExtraDollar { get; set; }
    }
}

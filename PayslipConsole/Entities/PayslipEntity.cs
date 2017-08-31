using PayslipConsole.Abstracts;

namespace PayslipConsole.Entities
{
    public class PayslipEntity : BaseValidPayslip
    {
        public PayslipEntity(string firstName, string lastName, PayPeriod payPeriod, double grossIncome, double incomeTax, double netIncome, double superAnnuation)
        {
            FirstName = firstName;
            LastName = lastName;
            PayPeriod = payPeriod;
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            SuperAnnuation = superAnnuation;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + "," + PayPeriod + "," + GrossIncome + "," + IncomeTax + "," + NetIncome + "," + SuperAnnuation;
        }

        public override bool Equals(object obj)
        {
            var item = obj as PayslipEntity;

            if (item == null)
            {
                return false;
            }
            return FirstName.Equals(item.FirstName)
                   && LastName.Equals(item.LastName)
                   && PayPeriod.Equals(item.PayPeriod)
                   && GrossIncome.Equals(item.GrossIncome)
                   && IncomeTax.Equals(item.IncomeTax)
                   && NetIncome.Equals(item.NetIncome)
                   && SuperAnnuation.Equals(item.SuperAnnuation);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public double GrossIncome { get; set; }
        public double IncomeTax { get; set; }
        public double NetIncome { get; set; }
        public double SuperAnnuation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        internal PayPeriod PayPeriod { get; set; }
    }
}

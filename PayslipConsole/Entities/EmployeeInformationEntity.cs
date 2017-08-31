using System;
using PayslipConsole.Abstracts;
using PayslipConsole.CustomExceptions;

namespace PayslipConsole.Entities
{
    class EmployeeInformationEntity : BasePayslipInformation
    {
        public double AnnualSalary { get; }
        public double SuperRate { get; }
        public PayPeriod PaymentPeriod { get; }

        public EmployeeInformationEntity(string firstName, string lastName, string annualSalary, string superRate, string paymentPeriod) : base(firstName, lastName)
        {
            try { AnnualSalary = double.Parse(annualSalary); }
            catch (FormatException)
            {
                throw new InvalidPayslipException("Annual Salary needs to be a number!");
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new InvalidPayslipException("Annual Salary is too high or low!");
            }

            if (AnnualSalary < 0)
            {
                throw new InvalidPayslipException("AnnualSalary is negative!");
            }

            superRate = superRate.Replace("%", "");
            try { SuperRate = double.Parse(superRate); }
            catch (FormatException)
            {
                throw new InvalidPayslipException("SuperRate needs to be a number!");
            }

            if (SuperRate < 0 || 100 < SuperRate)
            {
                throw new InvalidPayslipException("AnnualSalary must be between 0 - 100%!");
            }

            try { PaymentPeriod = ParsePayPeriod(paymentPeriod); }
            catch (FormatException)
            {
                throw new InvalidPayslipException("PaymentPeriod is not formatted correctly!");
            }

        }

        public PayPeriod ParsePayPeriod(string payPeriod)
        {
            return new PayPeriod(payPeriod);
        }

        public override string ToString()
        {
            return FirstName + "," + LastName + "," + AnnualSalary.ToString("0.#") + "," + SuperRate.ToString("0.#") + "%," + PaymentPeriod;
        }
    }
}

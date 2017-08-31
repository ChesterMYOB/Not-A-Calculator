using System;
using System.Collections.Generic;
using System.Linq;
using PayslipConsole.Abstracts;
using PayslipConsole.CustomExceptions;
using PayslipConsole.Entities;
using PayslipConsole.Interfaces;

namespace PayslipConsole.Core.EmployeePayslip
{
    internal class TargetedPeriod
    {
        public const int Daily = 365, Weekly = 52, Monthy = 12, Yearly = 1;
    }

    internal class EmployeePayslipCalculator : IPayslipCalculator
    {
        private readonly List<TaxBracket> _taxBrackets;
        private readonly int _targetedPeriod;

        public EmployeePayslipCalculator(List<TaxBracket> taxBrackets, int targetedPeriod)
        {
            _taxBrackets = taxBrackets;
            _targetedPeriod = targetedPeriod;
        }

        public EmployeePayslipCalculator()
        {
            var taxBracket1 = new TaxBracket(0, 18200, 0, 0);
            var taxBracket2 = new TaxBracket(18201, 37000, 0, 19);
            var taxBracket3 = new TaxBracket(37001, 80000, 3572, 32.5);
            var taxBracket4 = new TaxBracket(80001, 180000, 17547, 37);
            var taxBracket5 = new TaxBracket(180001, double.MaxValue, 54232, 45);
            _taxBrackets = new List<TaxBracket> { taxBracket1, taxBracket2, taxBracket3, taxBracket4, taxBracket5 };
            _targetedPeriod = TargetedPeriod.Monthy;
        }

        public virtual (BaseValidPayslip validPayslip, BaseInvalidPayslip invalidPayslip) Calculate(BasePayslipInformation basePayslipInformation)
        {
            var employeeDetails = (EmployeeInformationEntity)basePayslipInformation;
            PayslipEntity payslip = null;
            InvalidEmployeeInformationEntity invalidEmployeeInfo = null;
            try
            {
                var grossIncome = CalculateGrossIncome(employeeDetails.AnnualSalary);
                var incomeTax = CalculateIncomeTax(employeeDetails.AnnualSalary);
                var netIncome = CalculateNetIncome(grossIncome, incomeTax);
                var superAnnuation = CalculateSuperAnnuation(grossIncome, employeeDetails.SuperRate);
                payslip = new PayslipEntity(employeeDetails.FirstName, employeeDetails.LastName, employeeDetails.PaymentPeriod, grossIncome, incomeTax, netIncome, superAnnuation);
            }
            catch (InvalidPayslipException ex)
            {
                invalidEmployeeInfo = new InvalidEmployeeInformationEntity(employeeDetails.ToString(), ex.Message);
            }
            return (payslip, invalidEmployeeInfo);
        }

        public double CalculateGrossIncome(double annualSalary)
        {
            var roundedGrossIncome = Math.Round(annualSalary / _targetedPeriod);
            return roundedGrossIncome;
        }

        public double CalculateIncomeTax(double annualSalary)
        {
            var incomeTaxBracket = DetermineTaxBracket(annualSalary);
            var additionalTax = (annualSalary - incomeTaxBracket.Floor) * incomeTaxBracket.AdditionalTaxPerExtraDollar / 100;
            var incomeTax = Math.Round((incomeTaxBracket.BaseTax + additionalTax) / _targetedPeriod);
            return incomeTax;
        }

        public TaxBracket DetermineTaxBracket(double annualSalary)
        {
            return _taxBrackets.FirstOrDefault(taxBracket => taxBracket.Floor < annualSalary && annualSalary < taxBracket.Ceiling);
        }

        public double CalculateNetIncome(double grossIncome, double incomeTax)
        {
            return grossIncome - incomeTax;
        }

        public double CalculateSuperAnnuation(double grossIncome, double superRate)
        {
            return Math.Round(grossIncome * superRate / 100);
        }
    }
}

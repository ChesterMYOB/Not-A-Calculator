using System;
using PayslipConsole.Abstracts;
using PayslipConsole.Entities;
using PayslipConsole.Interfaces;

namespace PayslipConsole.PayslipServices
{
    internal class ValidPayslipService : IValidPayslipService
    {
        public void Handle(BaseValidPayslip baseValidPayslip)
        {
            var payslip = (PayslipEntity)baseValidPayslip;
            Console.WriteLine(payslip.ToString());
        }
    }

}

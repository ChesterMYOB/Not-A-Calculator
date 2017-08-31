using System;
using System.Collections.Generic;
using PayslipConsole.Abstracts;
using PayslipConsole.Entities;
using PayslipConsole.Interfaces;

namespace PayslipConsole.PayslipServices
{
    internal class InvalidEmployeeInformationService : IInvalidPayslipService
    {
        public void PreProcessing(List<BaseInvalidPayslip> invalidPayslips)
        {
            Console.WriteLine("Payslip generator could NOT process " + invalidPayslips.Count + " employee details:");
            Console.WriteLine();
        }

        public void Handle(BaseInvalidPayslip baseInvalidPayslip)
        {
            InvalidEmployeeInformationEntity invalidEmployeeEmpInfo = (InvalidEmployeeInformationEntity)baseInvalidPayslip;
            Console.WriteLine("Input: " + invalidEmployeeEmpInfo.PayslipInformation);
            Console.WriteLine("Error: " + invalidEmployeeEmpInfo.ErrorMessage);
            Console.WriteLine();
        }

        public void PostProcessing()
        {
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
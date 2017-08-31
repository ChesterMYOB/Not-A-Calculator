using System;
using PayslipConsole.Core.EmployeePayslip;
using PayslipConsole.OtherClient;

namespace PayslipConsole.Core
{
    internal class PayslipProgram
    {
        private static void Main()
        {
            var payslipGenerator = new EmployeePayslipGenerator();
   
            Console.WriteLine("Payslip program executing\n");

            var payslips = payslipGenerator.ProcessPayslips();

            Console.WriteLine("Payslip Input:");
            Console.WriteLine(payslipGenerator.GetInputFile().Contents);      
            Console.WriteLine("\n----------------------------------------------------------------------------------------------\n");

            Console.WriteLine("Payslip Output:");       
            payslipGenerator.ProcessValidInputs(payslips.validPayslips);

            Console.WriteLine();
            Console.WriteLine("Payslip program completed");
            Console.WriteLine();
            Console.WriteLine("\n----------------------------------------------------------------------------------------------\n");

            payslipGenerator.ProcessInvalidInputs(payslips.invalidPayslips);


            // Simulate injection of a different implementation of payslip, calculator and processor

            SecretPayslipCalculator shhhhhCalculator = new SecretPayslipCalculator();
            SecretPayslipProcessor shhhhhProcessor = new SecretPayslipProcessor();
            SecretPayslipFileStructure shhhhhInput = new SecretPayslipFileStructure();

            var underTheTablePayslipGenerator = new EmployeePayslipGenerator(shhhhhInput, shhhhhCalculator, shhhhhProcessor);
            var shhhhhpayslips = payslipGenerator.ProcessPayslips();
            var JSONreturn = underTheTablePayslipGenerator.ProcessValidInputs(shhhhhpayslips.validPayslips);


        }
    }
}

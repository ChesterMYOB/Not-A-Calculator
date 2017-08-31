using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayslipConsole.Abstracts;
using PayslipConsole;
using PayslipConsole.Core;
using PayslipConsole.Core.EmployeePayslip;
using PayslipConsole.Entities;
using PayslipConsole.FileTypes;

namespace PayslipTests
{
    [TestClass]
    public class PayslipProgramTests
    {
        [TestMethod]
        public void PayslipProgram_WhenUsingGivenInputs()
        {
            const string contents = "David,Rudd,60050,9%,01 March – 31 March\nRyan,Chen,120000,10%,01 March – 31 March";
            var csv = new CsvInputFile(contents, new[] { '\n' }, new[] { ',' });
            var payslipGenerator = new EmployeePayslipGenerator(csv);

            var expectedReturnTuple = (
                new List<BaseValidPayslip> {
                new PayslipEntity("David", "Rudd", new PayPeriod("01 March – 31 March"), 5004, 922, 4082, 450),
                new PayslipEntity("Ryan", "Chen", new PayPeriod("01 March – 31 March"), 10000, 2696, 7304, 1000)
            },
                new List<BaseInvalidPayslip>()
            );

            var payslips = payslipGenerator.ProcessPayslips();

            CollectionAssert.AreEqual(expectedReturnTuple.Item1, payslips.validPayslips);
            CollectionAssert.AreEqual(expectedReturnTuple.Item2, payslips.invalidPayslips);
        }

        [TestMethod]
        public void PayslipProgram_WhenUsingErrorProneInputs()
        {
            const string contents = "David,Rudd,60050,-9%,01 March – 31 March\n120000,10%,01 March – 31 March";
            var csv = new CsvInputFile(contents, new[] { '\n' }, new[] { ',' });
            var payslipGenerator = new EmployeePayslipGenerator(csv);

            var expectedReturnTuple = (
                new List<BaseValidPayslip>(),
                new List<BaseInvalidPayslip>
                {
                    new InvalidEmployeeInformationEntity("David,Rudd,60050,-9%,01 March – 31 March",  "AnnualSalary must be between 0 - 100%!"),
                    new InvalidEmployeeInformationEntity("120000,10%,01 March – 31 March",  "Missing fields!")
                }
            );

            var payslips = payslipGenerator.ProcessPayslips();

            CollectionAssert.AreEqual(expectedReturnTuple.Item1, payslips.validPayslips);
            CollectionAssert.AreEqual(expectedReturnTuple.Item2, payslips.invalidPayslips);
        }
    }
}

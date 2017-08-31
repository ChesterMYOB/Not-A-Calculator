using PayslipConsole.Abstracts;
using System.Collections.Generic;

namespace PayslipConsole.Interfaces
{
    public interface IPayslipGenerator
    {
        (List<BaseValidPayslip> validPayslips, List<BaseInvalidPayslip> invalidPayslips) ProcessPayslips();
        (List<BaseValidPayslip> validPayslips, List<BaseInvalidPayslip> invalidPayslips) ProcessPayslips(
            List<BasePayslipInformation> processedPayslipInfo);
        string ProcessValidInputs(List<BaseValidPayslip> validPayslips);
        string ProcessInvalidInputs(List<BaseInvalidPayslip> invalidPayslips);
    }
}

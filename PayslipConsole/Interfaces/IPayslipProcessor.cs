using System.Collections.Generic;
using PayslipConsole.Abstracts;

namespace PayslipConsole.Interfaces
{
    public interface IPayslipProcessor
    {
        (List<BasePayslipInformation> validPayslipInformation, List<BaseInvalidPayslip> invalidPayslips) ProcessingInformation(BaseInputFile inputInputFile);
    }
}

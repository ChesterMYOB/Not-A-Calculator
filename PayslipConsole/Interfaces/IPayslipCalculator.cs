using PayslipConsole.Abstracts;

namespace PayslipConsole.Interfaces
{
    public interface IPayslipCalculator
    {
        (BaseValidPayslip validPayslip, BaseInvalidPayslip invalidPayslip) Calculate(BasePayslipInformation basePayslipInformation);
    }
}

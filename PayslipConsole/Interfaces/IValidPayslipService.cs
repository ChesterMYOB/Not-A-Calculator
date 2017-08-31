using PayslipConsole.Abstracts;

namespace PayslipConsole.Interfaces
{
    interface IValidPayslipService
    {
        void Handle(BaseValidPayslip invalidPayslip);
    }
}
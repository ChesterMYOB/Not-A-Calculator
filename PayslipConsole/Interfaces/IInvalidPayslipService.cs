using System.Collections.Generic;
using PayslipConsole.Abstracts;

namespace PayslipConsole.Interfaces
{
    internal interface IInvalidPayslipService
    {
        void PreProcessing(List<BaseInvalidPayslip> invalidObjects);
        void Handle(BaseInvalidPayslip baseInvalidPayslip);
        void PostProcessing();
    }
}
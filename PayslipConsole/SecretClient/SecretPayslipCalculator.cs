using PayslipConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayslipConsole.Abstracts;

namespace PayslipConsole.OtherClient
{
    class SecretPayslipCalculator : IPayslipCalculator
    {
        public (BaseValidPayslip validPayslip, BaseInvalidPayslip invalidPayslip) Calculate(BasePayslipInformation basePayslipInformation)
        {
            throw new NotImplementedException();
        }
    }
}

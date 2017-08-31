using System;
using PayslipConsole.Abstracts;
using PayslipConsole.Interfaces;

namespace PayslipConsole.SecretClient
{
    class SecretPayslipService : IValidPayslipService
    {
        public void Handle(BaseValidPayslip invalidPayslip)
        {
            throw new NotImplementedException();
        }
    }
}

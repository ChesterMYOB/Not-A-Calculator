using PayslipConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayslipConsole.Abstracts;

namespace PayslipConsole.OtherClient
{
    class SecretPayslipProcessor : IPayslipProcessor
    {
        public (List<BasePayslipInformation> validPayslipInformation, List<BaseInvalidPayslip> invalidPayslips) ProcessingInformation(BaseInputFile inputInputFile)
        {
            throw new NotImplementedException();
        }
    }
}

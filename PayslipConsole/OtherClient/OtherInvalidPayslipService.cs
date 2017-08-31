using PayslipConsole.Abstracts;
using System;
using System.Collections.Generic;
using PayslipConsole.Interfaces;

namespace PayslipConsole.OtherClient
{
    class OtherInvalidPayslipService : IInvalidPayslipService
    {
        public void Handle(BaseInvalidPayslip baseInvalidPayslip)
        {
            // Example things you could do to handle this type of object

            // Send obj to webserver
            // Send obj to local storge
            // Log obj and it's error
            // Print to console
            // Do nothing

            throw new NotImplementedException();
        }

        public void PostProcessing()
        {
            throw new NotImplementedException();
        }

        public void PreProcessing(List<BaseInvalidPayslip> invalidObjects)
        {
            throw new NotImplementedException();
        }
    }
}

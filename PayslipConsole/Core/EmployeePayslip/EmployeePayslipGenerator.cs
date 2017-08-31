using System.Collections.Generic;
using PayslipConsole.Abstracts;
using PayslipConsole.FileTypes;
using PayslipConsole.Interfaces;

namespace PayslipConsole.Core.EmployeePayslip
{
    public class EmployeePayslipGenerator : IPayslipGenerator
    {
        private readonly BaseInputFile _inputFile;
        private readonly IPayslipProcessor _payslipProcessor;
        private readonly IPayslipCalculator _payslipCalculator;    
        private readonly List<BaseValidPayslip> _validPayslips;
        private readonly List<BaseInvalidPayslip> _invalidPayslips;
        
        public BaseInputFile GetInputFile()
        {
            return _inputFile;
        }

        public EmployeePayslipGenerator()
        {
            _inputFile = new CsvInputFile();
            _payslipCalculator = new EmployeePayslipCalculator();
            _payslipProcessor = new EmployeePayslipProcessor();
            _validPayslips = new List<BaseValidPayslip>();
            _invalidPayslips = new List<BaseInvalidPayslip>();
        }

        public EmployeePayslipGenerator(BaseInputFile inputFile)
        {
            _inputFile = inputFile;
            _payslipCalculator = new EmployeePayslipCalculator();
            _payslipProcessor = new EmployeePayslipProcessor();
            _validPayslips = new List<BaseValidPayslip>();
            _invalidPayslips = new List<BaseInvalidPayslip>();
        }

        public EmployeePayslipGenerator(BaseInputFile inputFile, IPayslipCalculator payslipCalculator, IPayslipProcessor payslipPayslipProcessor)
        {
            _inputFile = inputFile;
            _payslipCalculator = payslipCalculator;
            _payslipProcessor = payslipPayslipProcessor;
            _validPayslips = new List<BaseValidPayslip>();
            _invalidPayslips = new List<BaseInvalidPayslip>();
        }

        public (List<BaseValidPayslip> validPayslips, List<BaseInvalidPayslip> invalidPayslips) ProcessPayslips()
        {
            var processedPayslipInfo = _payslipProcessor.ProcessingInformation(_inputFile);
            _invalidPayslips.AddRange(processedPayslipInfo.invalidPayslips); 
            return ProcessPayslips(processedPayslipInfo.validPayslipInformation);           
        }

        public (List<BaseValidPayslip> validPayslips, List<BaseInvalidPayslip> invalidPayslips) ProcessPayslips(List<BasePayslipInformation> processedPayslipInfo)
        {
            foreach (var payslipInfo in processedPayslipInfo)
            {
                CreatePayslipForEmployee(payslipInfo);
            }
            return (_validPayslips, _invalidPayslips);
        }

        private void CreatePayslipForEmployee(BasePayslipInformation basePayslipInfo)
        {
            var payslip = _payslipCalculator.Calculate(basePayslipInfo);
            if (payslip.validPayslip != null)
            {
                _validPayslips.Add(payslip.validPayslip);
            }
            if (payslip.invalidPayslip != null)
            {
                _invalidPayslips.Add(payslip.invalidPayslip);
            }
        }

        public string ProcessValidInputs(List<BaseValidPayslip> validPayslips)
        {
            PayslipServiceFactory.HandleValidPayslips(validPayslips);
            return "Printed to console!";
        }

        public string ProcessInvalidInputs(List<BaseInvalidPayslip> invalidPayslips)
        {
            PayslipServiceFactory.HandleInvalidPayslips(invalidPayslips);
            return "Printed to console!";
        }      
    }
}
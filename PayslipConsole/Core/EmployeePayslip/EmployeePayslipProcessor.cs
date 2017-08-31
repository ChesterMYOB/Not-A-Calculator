using System;
using System.Collections.Generic;
using PayslipConsole.Abstracts;
using PayslipConsole.CustomExceptions;
using PayslipConsole.Entities;
using PayslipConsole.FileTypes;
using PayslipConsole.Interfaces;

namespace PayslipConsole.Core.EmployeePayslip
{
    internal enum ProcessingType
    {
        EmployeePayslip,
        Other
    }

    internal class EmployeePayslipProcessor : IPayslipProcessor
    {
        private readonly ProcessingType _typeOfPayslipToProcess;
        private List<BasePayslipInformation> _processedList;
        private List<BaseInvalidPayslip> _invalidObjects;

        public EmployeePayslipProcessor()
        {
            _typeOfPayslipToProcess = ProcessingType.EmployeePayslip;          
        }
        public EmployeePayslipProcessor(ProcessingType typeOfPayslipToProcess)
        {
            _typeOfPayslipToProcess = typeOfPayslipToProcess;        
        }

        public (List<BasePayslipInformation> validPayslipInformation, List<BaseInvalidPayslip> invalidPayslips) ProcessingInformation(BaseInputFile inputInputFile)
        {
            _processedList = new List<BasePayslipInformation>();
            _invalidObjects = new List<BaseInvalidPayslip>();

            switch (_typeOfPayslipToProcess)
            {
                case ProcessingType.EmployeePayslip:
                    {
                        ProcessEmployeePayslip((CsvInputFile)inputInputFile);
                        break;
                    }
                case ProcessingType.Other:
                    {
                        ProcessOtherPayslip(inputInputFile);
                        break;
                    }
                default:
                    {
                        ProcessDefaultPayslip(inputInputFile);
                        break;
                    }
            }

            return (_processedList, _invalidObjects);
        }

        private void ProcessEmployeePayslip(CsvInputFile inputFile)
        {
            // Loop through each line of the CSV File
            var lines = inputFile.GetListOfObjectInFileAsStrings();
            foreach (var line in lines)
            {
                // Try create an EmployeeInformationEntity 
                var parts = line.Split(inputFile.PartSeparator, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 5)
                {
                    _invalidObjects.Add(new InvalidEmployeeInformationEntity(line, "Missing fields!"));
                }
                else
                {
                    try
                    {
                        _processedList.Add(new EmployeeInformationEntity(parts[0], parts[1], parts[2], parts[3], parts[4]));
                    }
                    catch (InvalidPayslipException ex)
                    {
                        _invalidObjects.Add(new InvalidEmployeeInformationEntity(line, ex.Message));
                    }
                }
            }
        }

        private void ProcessOtherPayslip(BaseInputFile inputFile)
        {
            inputFile.GetListOfObjectInFileAsStrings();
            Console.WriteLine("I AM ANOTHER PAYSLIP FORMAT!");
        }
        private void ProcessDefaultPayslip(BaseInputFile inputFile)
        {
            inputFile.GetListOfObjectInFileAsStrings();
            Console.WriteLine("I AM THE DEFAULT PAYSLIP FORMAT");
        }


    }
}

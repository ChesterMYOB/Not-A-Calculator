using System;
using System.Collections.Generic;
using PayslipConsole.Abstracts;
using PayslipConsole.Entities;
using PayslipConsole.Interfaces;
using PayslipConsole.OtherClient;
using PayslipConsole.PayslipServices;

namespace PayslipConsole.Core.EmployeePayslip
{
    internal static class PayslipServiceFactory
    {
        private static readonly Dictionary<Type, IValidPayslipService> ValidHandlerPool;
        private static IValidPayslipService _validService;
        private static readonly Dictionary<Type, IInvalidPayslipService> InvalidHandlerPool;
        private static IInvalidPayslipService _invalidService;

        static PayslipServiceFactory()
        {
            ValidHandlerPool = new Dictionary<Type, IValidPayslipService>
                {
                    {typeof(PayslipEntity), new ValidPayslipService()}
                };

            InvalidHandlerPool = new Dictionary<Type, IInvalidPayslipService>
            {
                {typeof(InvalidEmployeeInformationEntity), new InvalidEmployeeInformationService()},
                {typeof(OtherBaseInvalidPayslip), new OtherInvalidPayslipService()}
            };
        }

        public static void HandleInvalidPayslips(List<BaseInvalidPayslip> invalidObjects)
        {
            if (invalidObjects.Count > 0)
            {
                _invalidService = InvalidHandlerPool[invalidObjects[0].GetType()];

                _invalidService.PreProcessing(invalidObjects);

                foreach (var invalidObject in invalidObjects)
                {
                    _invalidService.Handle(invalidObject);
                }

                _invalidService.PostProcessing();
            }
            else
            {
                Console.WriteLine("END");
                Console.ReadLine();
            }
        }

        public static void HandleValidPayslips(List<BaseValidPayslip> validObjects)
        {
            if (validObjects.Count > 0)
            {
                _validService = ValidHandlerPool[validObjects[0].GetType()];
                foreach (var validObject in validObjects)
                {
                    _validService.Handle(validObject);
                }
            }
        }
    }
}

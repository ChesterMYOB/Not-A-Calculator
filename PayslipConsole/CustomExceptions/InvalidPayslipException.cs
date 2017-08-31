using System;
using System.Runtime.Serialization;
using PayslipConsole.Abstracts;
using PayslipConsole.Entities;

namespace PayslipConsole.CustomExceptions
{
    [Serializable]
    internal class InvalidPayslipException : Exception
    {
        private BaseInvalidPayslip _baseInvalidPayslip;

        public InvalidPayslipException()
        {
        }

        public InvalidPayslipException(string message) : base(message)
        {
        }

        public InvalidPayslipException(string invalidObject, string errorMessage)
        {
            BaseInvalidPayslip = new InvalidEmployeeInformationEntity(invalidObject, errorMessage);
        }

        public InvalidPayslipException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPayslipException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        internal BaseInvalidPayslip BaseInvalidPayslip { get => _baseInvalidPayslip; set => _baseInvalidPayslip = value; }
    }
}
using PayslipConsole.Abstracts;

namespace PayslipConsole.Entities
{
    public class InvalidEmployeeInformationEntity : BaseInvalidPayslip
    {
        public InvalidEmployeeInformationEntity(string payslipInformation, string errorMessage)
        {
            PayslipInformation = payslipInformation;
            ErrorMessage = errorMessage;
        }
    }
}

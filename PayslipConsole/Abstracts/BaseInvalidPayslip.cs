namespace PayslipConsole.Abstracts
{
    public abstract class BaseInvalidPayslip
    {
        public string ErrorMessage { get; set; }
        public string PayslipInformation { get; set; }     
    }
}

namespace PayslipConsole.Abstracts
{
    public abstract class BasePayslipInformation
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected BasePayslipInformation() { }

        protected BasePayslipInformation(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }    
    }
}
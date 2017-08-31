namespace PayslipConsole.Abstracts
{
    public abstract class BaseInputFile
    {
        public string Contents { get; set; }
        public string ExpectedOutput { get; set; }
        public char[] PartSeparator { get; set; } = { ',' };

        public abstract string[] GetListOfObjectInFileAsStrings();
    }
}

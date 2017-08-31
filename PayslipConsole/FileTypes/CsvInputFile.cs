using PayslipConsole.Abstracts;

namespace PayslipConsole.FileTypes
{
    public class CsvInputFile : BaseInputFile
    {
        private char[] _lineSeparator = { '\n' };

        public char[] LineSeparator { get => _lineSeparator; set => _lineSeparator = value; }

        public CsvInputFile()
        {
            Contents = "David,Rudd,60050,9%,01 March – 31 March\nRyan,Chen,120000,10%,01 March – 31 March";
            ExpectedOutput = "David Rudd,01 March – 31 March,5004,922,4082,450\nRyan Chen,01 March – 31 March,10000,2696,7304,1000";
        }

        public CsvInputFile(string input, char[] lineSeparator, char[] informationSeparator)
        {
            Contents = input;
            ExpectedOutput = "David Rudd,01 March – 31 March,5004,922,4082,450\nRyan Chen,01 March – 31 March,10000,2696,7304,1000";
            _lineSeparator = lineSeparator;
            PartSeparator = informationSeparator;
        }

        public override string[] GetListOfObjectInFileAsStrings()
        {
            return Contents.Split(_lineSeparator);
        }
    }
}

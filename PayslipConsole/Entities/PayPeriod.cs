using System;

namespace PayslipConsole.Entities
{
    public class PayPeriod
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Format { get; set; }
        public char Separator { get; set; }

        public PayPeriod(string timePeriod)
        {
            Format = "m";
            Separator = '–';
            var dates = timePeriod.Split(Separator);
            StartDate = Convert.ToDateTime(dates[0]);
            EndDate = Convert.ToDateTime(dates[1]);
        }

        public PayPeriod(string timePeriod, char separator, string format)
        {
            var dates = timePeriod.Split(separator);
            Separator = separator;
            Format = format;
            StartDate = Convert.ToDateTime(dates[0]);
            EndDate = Convert.ToDateTime(dates[1]);
        }

        public override string ToString()
        {
            var startDateFormatted = StartDate.Date.ToString(Format);
            var endDateFormatted = EndDate.Date.ToString(Format);

            return startDateFormatted + " " + char.ToString(Separator) + " " + endDateFormatted;
        }

        public override bool Equals(object obj)
        {
            var item = obj as PayPeriod;

            if (item == null)
            {
                return false;
            }
            return StartDate.Equals(item.StartDate) 
                && EndDate.Equals(item.EndDate) 
                && Format.Equals(item.Format) 
                && Separator.Equals(item.Separator);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}

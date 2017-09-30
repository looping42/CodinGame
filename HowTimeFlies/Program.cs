using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowTimeFlies
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string BEGIN = Console.ReadLine();
            string END = Console.ReadLine();
            DateTime datetimestart = DateTime.ParseExact(BEGIN, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime datetimeend = DateTime.ParseExact(END, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            TimeSpan ts = datetimeend - datetimestart;
            DateTime datetimestartTemp = datetimestart;
            DateTime datetimeendTemp = datetimeend;

            // Difference in days.
            int differenceInDays = ts.Days;

            int diffinyears = 0;
            while (datetimestartTemp.AddYears(diffinyears) <= datetimeendTemp)
            {
                datetimestartTemp = datetimestartTemp.AddYears(1);
                diffinyears++;
            }

            //datetimestartTemp = datetimestart;
            datetimeendTemp = datetimeend;

            int diffinmonth = 0;
            //diff in month
            while (datetimestartTemp.AddMonths(1) <= datetimeendTemp)
            {
                datetimestartTemp = datetimestartTemp.AddMonths(1);
                diffinmonth++;
            }

            string month = "";
            if (diffinmonth == 1)
            {
                month = "month";
            }
            else
            {
                month = "months";
            }
            string years = "";
            if (diffinyears == 1)
            {
                years = "year";
            }
            else
            {
                years = "years";
            }

            if (diffinyears > 0)
            {
                if (diffinmonth > 0)
                    Console.WriteLine(string.Format("{0} {1}, {2} {3}, total {4} days", diffinyears, years, diffinmonth, month, differenceInDays));
                else
                    Console.WriteLine(string.Format("{0} {1}, total {2} days", diffinyears, years, differenceInDays));
            }
            else if (diffinmonth > 0)
            {
                Console.WriteLine(string.Format("{0} {1}, total {2} days", diffinmonth, month, differenceInDays));
            }
            else
            {
                Console.WriteLine(string.Format("total {0} days", differenceInDays));
            }
        }
    }
}
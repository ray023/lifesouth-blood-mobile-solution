using o1Solution.LifeSouthDonor.Lib.Interfaces;
using System;

namespace o1Solution.LifeSouthDonor.Lib.Reporter
{
    public class ConsoleReporter : IImportReporter
    {
        public void ReportException(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        public void ReportInfo(string infoToReport)
        {
            Console.WriteLine(infoToReport);
        }
    }
}

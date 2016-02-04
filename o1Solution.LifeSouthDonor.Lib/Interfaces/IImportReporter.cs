using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace o1Solution.LifeSouthDonor.Lib.Interfaces
{
    public interface IImportReporter
    {
        void ReportInfo(string infoToReport);
        void ReportException(Exception ex);
    }
}

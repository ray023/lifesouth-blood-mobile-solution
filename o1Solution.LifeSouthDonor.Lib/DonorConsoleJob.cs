using o1Solution.LifeSouthDonor.Lib.Interfaces;
using o1Solution.LifeSouthDonor.Lib.Helpers;
using o1Solution.LifeSouthDonor.Lib.Business;
using o1Solution.LifeSouthDonor.Lib.Reporter;

namespace o1Solution.LifeSouthDonor.Lib
{
    public class DonorConsoleJob : IConsoleJob
    {
        public void GetToWork()
        {
            IImportReporter reporter = new ConsoleReporter();
            reporter.ReportInfo("Starting work...");
            reporter.ReportInfo("Getting donation data.");
            string javascriptText = JsonHelper.RemoveCarriageReturns(WebHelper.GetDonationDriveFromWeb());
            ObjectBuilder ob = new ObjectBuilder(javascriptText);
            reporter.ReportInfo("Getting blood mobile drives.");
            var bmds = ob.GetBloodMobileDrives();
            reporter.ReportInfo("Getting donation centers.");
            var donorCenters = ob.GetDonationCenters();
            reporter.ReportInfo("Merge donor sources; may not end up using this...");
            var mergedDonorSources = ob.MergeDonorSources(bmds, donorCenters);
            reporter.ReportInfo("Saving Data.");
            ModelHelper.SaveDonorDriveData(bmds, donorCenters, mergedDonorSources);
            reporter.ReportInfo("Operation complete.");
        }
    }
}

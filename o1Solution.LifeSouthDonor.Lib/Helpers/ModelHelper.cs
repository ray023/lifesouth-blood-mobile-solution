using o1Solution.LifeSouthDonor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace o1Solution.LifeSouthDonor.Lib.Helpers
{
    public class ModelHelper
    {
        public static void SaveDonorDriveData(List<BloodMobileDrive> bmds, List<DonationCenter> donorCenters, List<MergedDonorSource> mdsList)
        {
            using (var context = new o1Solution.LifeSouthDonor.Data.LifeSouthDonorModelContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE BloodMobileDrive");
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE DonationCenter;");
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE MergedDonorSources;");
                context.BloodMobileDrives.AddRange(bmds);
                context.DonationCenters.AddRange(donorCenters);
                context.MergedDonorSources.AddRange(mdsList);
                context.SaveChanges();
            }
        }
    }
}

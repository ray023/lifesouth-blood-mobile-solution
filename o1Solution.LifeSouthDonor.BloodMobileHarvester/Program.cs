using o1Solution.LifeSouthDonor.Lib;
using o1Solution.LifeSouthDonor.Lib.Interfaces;

namespace o1Solution.LifeSouthDonor.BloodMobileHarvester
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsoleJob icb = new DonorConsoleJob();
            icb.GetToWork();
        }
    }
}

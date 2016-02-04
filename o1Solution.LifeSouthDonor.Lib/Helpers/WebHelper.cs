using System.Text;
using System.IO;
using System.Configuration;

namespace o1Solution.LifeSouthDonor.Lib.Helpers
{
    public class WebHelper
    {
        public static string GetDonationDriveFromWeb()
        {
            string sourceUrl = ConfigurationManager.AppSettings["JsDataSourceUrl"];
            using (var wc = new System.Net.WebClient())
            using (MemoryStream stream = new MemoryStream(wc.DownloadData(sourceUrl)))
                return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}

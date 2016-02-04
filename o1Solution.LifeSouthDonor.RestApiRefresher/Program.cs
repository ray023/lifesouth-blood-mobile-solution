using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace o1Solution.LifeSouthDonor.RestApiRefresher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pretty lame console job to keep the web api active.  
            //Otherwise, user could be waiting up to 15 seconds for data to be returned
            string url = "http://o1solutionlifesouthdonorweb.azurewebsites.net/api/BloodMobileDrives/?latitude=33.6705438&longitude=-86.4199482";
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            System.Diagnostics.Debug.WriteLine(result);
        }
    }
}

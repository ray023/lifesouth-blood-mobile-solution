using o1Solution.LifeSouthDonor.Data;
using o1Solution.LifeSouthDonor.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace o1Solution.LifeSouthDonor.Lib.Business
{
    public class ObjectBuilder
    {
        string _textContainingJson;
        List<BloodMobileDrive> _bmdList = null;
        List<DonationCenter> _donorCenteList = null;
        public ObjectBuilder(string textContainingJson)
        {
            _textContainingJson = textContainingJson;
        }

        public List<BloodMobileDrive> GetBloodMobileDrives()
        {
            if (_bmdList != null)
                return _bmdList;

            const string HEADER_TEXT = "{\"DRIVEID\":";
            _bmdList = new List<BloodMobileDrive>();

            Dictionary<string, List<string>> driveData = JsonHelper.ParseJsonDictionaryFromString(_textContainingJson, HEADER_TEXT);
            int fieldCount = driveData.Count();
            for (int i = 0; i < driveData.FirstOrDefault().Value.Count; i++)
            {
                BloodMobileDrive bmd = new BloodMobileDrive();
                bmd.DriveId = int.Parse(driveData["DRIVEID"][i]);
                bmd.DriveDate = DateTime.Parse(driveData["DRIVEDATE"][i]);
                bmd.StartTime = DateTime.Parse(string.Concat(driveData["DRIVEDATE"][i], " ", driveData["STARTTIME"][i]));
                bmd.EndTime = DateTime.Parse(string.Concat(driveData["DRIVEDATE"][i], " ", driveData["ENDTIME"][i]));
                bmd.Location = driveData["LOCATION"][i];
                bmd.Address = driveData["ADDRESS"][i];
                bmd.City = driveData["CITY"][i];
                bmd.State = driveData["STATE"][i];
                bmd.Zip = driveData["ZIP"][i];
                bmd.Latitude = Decimal.Parse(driveData["LATITUDE"][i]);
                bmd.Longitude = Decimal.Parse(driveData["LONGITUDE"][i]);
                bmd.LatitudeLongitude = System.Data.Entity.Spatial.DbGeography.FromText("POINT("+ bmd.Longitude + " " + bmd.Latitude + ")");

                _bmdList.Add(bmd);
            }

            return _bmdList;
        }

        public List<DonationCenter> GetDonationCenters()
        {
            if (_donorCenteList != null)
                return _donorCenteList;

            const string HEADER_TEXT = "{\"CENTERID\":";
            _donorCenteList = new List<DonationCenter>();

            Dictionary<string, List<string>> donorCenterData = JsonHelper.ParseJsonDictionaryFromString(_textContainingJson, HEADER_TEXT);

            int fieldCount = donorCenterData.Count();
            for (int i = 0; i < donorCenterData.FirstOrDefault().Value.Count; i++)
            {
                DonationCenter donorCenter = new DonationCenter();
                donorCenter.CenterId = int.Parse(donorCenterData["CENTERID"][i]);
                donorCenter.Location = donorCenterData["LOCATION"][i];
                donorCenter.Address = donorCenterData["ADDRESS"][i];
                donorCenter.City = donorCenterData["CITY"][i];
                donorCenter.State = donorCenterData["STATE"][i];
                donorCenter.Zip = donorCenterData["ZIP"][i];
                donorCenter.Latitude = Decimal.Parse(donorCenterData["LATITUDE"][i]);
                donorCenter.Longitude = Decimal.Parse(donorCenterData["LONGITUDE"][i]);
                donorCenter.LatitudeLongitude = System.Data.Entity.Spatial.DbGeography.FromText("POINT(" + donorCenter.Longitude + " " + donorCenter.Latitude + ")");

                _donorCenteList.Add(donorCenter);
            }
            return _donorCenteList;
        }
        public List<MergedDonorSource> MergeDonorSources(List<BloodMobileDrive> bmds, List<DonationCenter> donorCenters)
        {
            List<MergedDonorSource> mdsList = new List<MergedDonorSource>();
            foreach (var item in bmds)
            {
                MergedDonorSource mds = new MergedDonorSource();
                mds.SourceTableKeyId = item.DriveId;
                mds.DonationSource = "Bloodmobile";
                mds.DriveDate = item.DriveDate;
                mds.StartTime = item.StartTime;
                mds.EndTime = item.EndTime;
                mds.Location = item.Location;
                mds.Address = item.Address;
                mds.City = item.City;
                mds.State = item.State;
                mds.Zip = item.Zip;
                mds.LatitudeLongitude = item.LatitudeLongitude;

                mdsList.Add(mds);
            }
            foreach (var item in donorCenters)
            {
                MergedDonorSource mds = new MergedDonorSource();
                mds.SourceTableKeyId = item.CenterId;
                mds.DonationSource = "Donation Center";
                mds.Location = item.Location;
                mds.Address = item.Address;
                mds.City = item.City;
                mds.State = item.State;
                mds.Zip = item.Zip;
                mds.LatitudeLongitude = item.LatitudeLongitude;

                mdsList.Add(mds);
            }
            return mdsList;
        }
    }
}

CREATE PROCEDURE [dbo].[p_GetDonationInformation]
	@latitude decimal(9,6),
	@longitude decimal(9,6)
AS

DECLARE @MILE_CONVERTER DECIMAL(8, 8) = 0.00062137
DECLARE @orig geography = geography::Point(@latitude, @longitude, 4326);

SELECT * FROM
(
	SELECT 
		bmd.DriveId,
		DriveDate,
		StartTime,
		EndTime,
		Location,
		NavLink = CONCAT('http://maps.google.com/?saddr=',@latitude,',',@longitude,'&daddr=', latitude, ',' , longitude),
		[Address],
		City,
		[State],
		Zip,
		Miles = @orig.STDistance(LatitudeLongitude) * @MILE_CONVERTER,
		DaysTill = DateDiff(DAY, GetDate(), EndTime),
		--Having trouble using the javscript Date Element to convert StartAndEndTime to the actual time
		--(something to do with TimeZones).  Using these fields instead
		StartHour = DatePart(hour,StartTime),
		StartMinute = DatePart(Minute,StartTime),
		EndHour = DatePart(hour,EndTime),
		EndMinute = DatePart(Minute,EndTime)
	FROM
		BloodMobileDrive bmd
) t
WHERE
	t.Miles < 50 AND
    t.DaysTill >= 0
ORDER BY 
	DaysTill, 
	Miles,
	StartTime
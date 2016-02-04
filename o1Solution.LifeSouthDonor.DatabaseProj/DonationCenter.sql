CREATE TABLE [dbo].[DonationCenter]
(
	[CenterId] INT NOT NULL PRIMARY KEY, 
    [Location] NCHAR(500) NULL, 
    [Address] NCHAR(500) NULL, 
    [City] NCHAR(500) NULL, 
    [State] NCHAR(20) NULL, 
    [Zip] NCHAR(20) NULL, 
    [Latitude] DECIMAL(9, 6) NULL, 
    [Longitude] DECIMAL(9, 6) NULL, 
    [LatitudeLongitude] [sys].[geography] NULL
)

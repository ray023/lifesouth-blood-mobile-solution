CREATE TABLE [dbo].[MergedDonorSources]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [SourceTableKeyId] INT NULL, 
    [DonationSource] NCHAR(500) NULL, 
    [DriveDate] DATETIME NULL, 
    [StartTime] DATETIME NULL, 
    [EndTime] DATETIME NULL, 
    [Location] NCHAR(500) NULL, 
    [Address] NCHAR(500) NULL, 
    [City] NCHAR(500) NULL, 
    [State] NCHAR(500) NULL, 
    [Zip] NCHAR(500) NULL, 
    [LatitudeLongitude] [sys].[geography] NULL
)

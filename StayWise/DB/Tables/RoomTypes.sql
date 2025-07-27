CREATE TABLE dbo.RoomTypes
(
    RoomTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(50) NOT NULL,       -- e.g., Deluxe, Suite, Standard
    Description NVARCHAR(255) NULL,
    MaxOccupancy INT NULL,
    BasePrice DECIMAL(10,2) NULL,
    CreatedBy NVARCHAR(50) NULL,
    UpdatedBy NVARCHAR(50) NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);

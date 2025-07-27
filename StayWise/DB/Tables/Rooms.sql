CREATE TABLE dbo.Rooms
(
    RoomID INT IDENTITY(1,1) PRIMARY KEY,
    HotelID INT NOT NULL FOREIGN KEY REFERENCES Hotels(HotelID),
    RoomNumber NVARCHAR(20) NOT NULL,
    Floor INT NULL,
    RoomTypeID INT FOREIGN KEY REFERENCES RoomTypes(RoomTypeID),
    IsAvailable BIT DEFAULT 1,
    Price DECIMAL(10,2) NULL,                  -- Override base price if needed
    Description NVARCHAR(255) NULL,
    CreatedBy NVARCHAR(50) NULL,
    UpdatedBy NVARCHAR(50) NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);

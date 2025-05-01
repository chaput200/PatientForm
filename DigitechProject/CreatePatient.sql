USE DigitechTestDB;  -- Replace with your database name if different
GO

-- Drop the stored procedure if it exists
IF OBJECT_ID('dbo.CreatePatient', 'P') IS NOT NULL
    DROP PROCEDURE dbo.CreatePatient;
GO

-- Now create the stored procedure
CREATE PROCEDURE CreatePatient
    @PatientKEY UNIQUEIDENTIFIER,
    @LastName VARCHAR(50),
    @FirstName VARCHAR(50),
    @MiddleInitial VARCHAR(1),
    @Address1 VARCHAR(100),
    @Address2 VARCHAR(100),
    @City VARCHAR(50),
    @State VARCHAR(2),
    @ZipCode VARCHAR(10),
    @HomePhone VARCHAR(20),
    @BusinessPhone VARCHAR(20),
    @CellPhone VARCHAR(20),
    @EmailAddress VARCHAR(250)
AS
BEGIN
    INSERT INTO Patients (
        PatientKEY, LastName, FirstName, MiddleInitial,
        Address1, Address2, City, State, ZipCode,
        HomePhone, BusineesPhone, CellPhone, EmailAddress
    )
    VALUES (
        @PatientKEY, @LastName, @FirstName, @MiddleInitial,
        @Address1, @Address2, @City, @State, @ZipCode,
        @HomePhone, @BusinessPhone, @CellPhone, @EmailAddress
    );
END;
GO

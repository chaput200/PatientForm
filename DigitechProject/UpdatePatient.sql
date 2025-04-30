USE DigitechTstDN;  -- Replace with your database name if different
GO

-- Drop the stored procedure if it exists
IF OBJECT_ID('dbo.UpdatePatient', 'P') IS NOT NULL
    DROP PROCEDURE dbo.UpdatePatient;
GO

CREATE PROCEDURE UpdatePatient
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
    UPDATE Patients
    SET 
        LastName = @LastName,
        FirstName = @FirstName,
        MiddleInitial = @MiddleInitial,
        Address1 = @Address1,
        Address2 = @Address2,
        City = @City,
        State = @State,
        ZipCode = @ZipCode,
        HomePhone = @HomePhone,
        BusineesPhone = @BusinessPhone,
        CellPhone = @CellPhone,
        EmailAddress = @EmailAddress
    WHERE PatientKEY = @PatientKEY;
END;
GO

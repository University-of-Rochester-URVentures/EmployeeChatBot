CREATE PROCEDURE [dbo].[Report_Create]
	@Username nvarchar(MAX),
	@Email nvarchar(MAX),
	@EmployeeId int
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	INSERT INTO dbo.Report
	(Email, Username, EmployeeId)
	VALUES (@Email, @Username, @EmployeeId)
	
	SELECT *
	FROM dbo.Report
	WHERE Report_ID = SCOPE_IDENTITY()
	
END
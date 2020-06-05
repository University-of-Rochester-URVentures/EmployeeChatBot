CREATE PROCEDURE [dbo].[Report_Check2]
	@Username nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	SELECT TOP(1) *
	FROM dbo.Report
	WHERE Employee_AdUsername = @Username 
		AND ReportSystem = 1
	ORDER BY CreatedAt DESC
END
CREATE PROCEDURE [dbo].[Report_CheckByUsername]
	@Username nvarchar(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	SELECT TOP(1) *
	FROM dbo.Report
	WHERE Username = @Username
	ORDER BY CreatedAt DESC
END
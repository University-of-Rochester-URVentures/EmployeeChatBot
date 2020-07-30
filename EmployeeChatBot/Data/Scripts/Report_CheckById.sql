CREATE PROCEDURE [dbo].[Report_CheckById]
	@ReportId int
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	SELECT *
	FROM dbo.Report
	WHERE Report_ID = @ReportId
END

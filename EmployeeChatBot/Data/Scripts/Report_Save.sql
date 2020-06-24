CREATE PROCEDURE [dbo].[Report_Save]
	@ReportId int,
	@Fever bit,
	@Breathing bit,
	@Coughing bit,
	@SoreThroat bit,
	@BodyAches bit,
	@LossOfSmell bit
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	
	UPDATE dbo.Report
		SET Fever = @Fever,
			Breathing = @Breathing,
			Coughing = @Coughing,
			SoreThroat = @SoreThroat,
			BodyAches = @BodyAches,
			LossOfTasteSmell = @LossOfSmell,
			CompletedAt = GETDATE()
	WHERE Report_ID = @ReportId
		AND CompletedAt IS NULL

END
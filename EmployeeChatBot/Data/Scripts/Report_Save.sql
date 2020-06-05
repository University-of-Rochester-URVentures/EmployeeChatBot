create PROCEDURE [dbo].[Report_Save3]
	@Username nvarchar(MAX),
	@URId int,
	@Email nvarchar(MAX),
	@Fever bit,
	@Breathing bit,
	@Coughing bit,
	@SoreThroat bit,
	@BodyAches bit,
	@Allergies bit
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	
	INSERT INTO dbo.Report (Employee_AdUsername, Employee_Email, Employee_URId, Fever, Breathing, Coughing, SoreThroat, BodyAches, Allergies)
	VALUES(@Username, @Email, @URId, @Fever, @Breathing, @Coughing, @SoreThroat, @BodyAches, @Allergies);
END
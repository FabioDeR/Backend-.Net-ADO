CREATE PROCEDURE [dbo].[GetActorInitial]
	@initialF char,
	@initialL char
AS
BEGIN
	SELECT *FROM Actor 
	WHERE LEFT (FirstName,1) = @initialF AND LEFT (LastName,1) = @initialL
END

CREATE PROCEDURE [dbo].[GetAllActorInitial]
	AS
	SELECT ActorId, UPPER(LEFT(LastName, 1)) as LastName, FirstName FROM Actor;
RETURN 0
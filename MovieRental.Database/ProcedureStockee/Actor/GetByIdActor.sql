CREATE PROCEDURE [dbo].[GetByIdActor]
	@Id int

AS
BEGIN
	SELECT*FROM Actor WHERE ActorId = @Id;
END
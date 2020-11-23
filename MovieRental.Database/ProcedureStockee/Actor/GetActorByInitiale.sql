CREATE PROCEDURE [dbo].[GetActorByInitiale]
	
    @LastL char
	
AS
BEGIN
	SELECT*FROM Actor
	WHERE LastName like @LastL + '%'
END
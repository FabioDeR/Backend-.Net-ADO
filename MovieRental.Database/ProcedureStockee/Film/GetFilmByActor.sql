CREATE PROCEDURE [dbo].[GetFilmByActor]
	@LastName varchar(50)
	
AS
BEGIN
	SELECT * FROM Film f, Actor a, FilmActor fa
	where a.ActorId = fa.ActorId
	AND f.FilmId = fa.FilmId
	AND a.LastName = @LastName;
END 

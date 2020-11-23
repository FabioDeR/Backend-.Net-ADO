CREATE PROCEDURE [dbo].[GetActorByFilm]
		@title varchar(50)
AS
BEGIN
	SELECT * FROM Actor a, Film f, FilmActor fa 
	WHERE a.ActorId = fa.ActorId AND f.FilmId = fa.FilmId AND f.Title = @title
END

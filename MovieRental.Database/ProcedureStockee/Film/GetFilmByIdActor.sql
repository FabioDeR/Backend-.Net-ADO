CREATE PROCEDURE [dbo].[GetFimByIdActor]
	@ActorId int
AS
	SELECT * FROM Film f, Actor a, FilmActor fa
	where a.ActorId = fa.ActorId
	AND f.FilmId = fa.FilmId
	AND a.ActorId = @ActorId;
RETURN 0
CREATE PROCEDURE [dbo].[GetFilmByIdCategory]
		@CategoryId int
AS
	SELECT * FROM Film f
	JOIN FilmCategory fc ON f.FilmId = fc.FilmId
	WHERE fc.CategoryId = @CategoryId;
RETURN 0

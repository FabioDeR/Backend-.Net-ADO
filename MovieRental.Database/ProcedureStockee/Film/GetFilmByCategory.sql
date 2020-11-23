CREATE PROCEDURE [dbo].[GetFilmByCategory]
@Name nvarchar(25)
AS
BEGIN
	SELECT * FROM Film f, Category c, FilmCategory fc 
	WHERE f.FilmId = fc.FilmId
	AND c.CategoryId = fc.CategoryId
	AND c.[Name] = @Name;
END

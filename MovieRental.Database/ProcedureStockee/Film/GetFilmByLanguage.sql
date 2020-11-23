CREATE PROCEDURE [dbo].[GetFilmByLanguage]
	@Language nvarchar(25)
	
AS
BEGIN
	SELECT * FROM Film f, [Language] l WHERE f.LanguageId = l.LanguageId
	AND l.[Name] = @Language;
END

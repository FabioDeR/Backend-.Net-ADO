CREATE PROCEDURE [dbo].[GetFilmByIdLanguage]


	@LanguageId int
AS
	SELECT * FROM Film f, [Language] l WHERE f.LanguageId = l.LanguageId
	AND l.[Name] = @LanguageId;
RETURN 0

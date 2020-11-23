CREATE PROCEDURE [dbo].[GetFilmByKeyWord]
	@KeyWord nvarchar(255)
AS
	SELECT * FROM Film WHERE [Description] like '%' + @KeyWord + '%';
RETURN 0
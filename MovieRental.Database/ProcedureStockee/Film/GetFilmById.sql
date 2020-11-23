CREATE PROCEDURE [dbo].[GetFilmById]
@Id int 
AS
BEGIN
	SELECT*FROM Film 
	WHERE FilmId = @Id;
END
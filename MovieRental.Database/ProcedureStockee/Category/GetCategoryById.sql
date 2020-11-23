CREATE PROCEDURE [dbo].[GetCategoryById]
	@Id int
AS
	SELECT * FROM Category WHERE CategoryId = @Id;
RETURN 0


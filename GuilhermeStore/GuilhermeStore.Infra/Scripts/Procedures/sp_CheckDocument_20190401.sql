CREATE PROCEDURE spCheckDocument 
	@Document CHAR(11)
AS 
	SELECT CASE WHEN EXISTS(
	SELECT Id 
	FROM GuilhermeStore.Customer 
	WHERE Document = @Document
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END

	


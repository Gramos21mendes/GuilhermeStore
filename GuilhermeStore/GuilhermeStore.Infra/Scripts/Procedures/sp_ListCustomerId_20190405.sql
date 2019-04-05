CREATE PROCEDURE spListCustomerId
@Id UNIQUEIDENTIFIER 
AS

SELECT [Id]
, CONCAT([Name],'',[LastName]) AS [Name]
, [Document]
, [Email] FROM GuilhermStore.Customer WHERE Id = @Id;
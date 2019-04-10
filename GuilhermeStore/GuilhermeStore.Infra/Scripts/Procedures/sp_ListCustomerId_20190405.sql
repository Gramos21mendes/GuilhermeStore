CREATE PROCEDURE spListCustomerId
@Id UNIQUEIDENTIFIER 
AS

SELECT [Id]
, CONCAT([FirstName],' ',[LastName]) AS [Name]
, [Document]
, [Email] FROM GuilhermeStore.Customer WHERE Id = @Id;
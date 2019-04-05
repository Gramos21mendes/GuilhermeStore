CREATE PROCEDURE spListCustomer
AS
SELECT [Id]
, CONCAT([Name],'',[LastName]) AS [Name]
, [Document]
, [Email] FROM GuilhermStore.Customer
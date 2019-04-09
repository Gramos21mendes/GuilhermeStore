CREATE PROCEDURE spDeleteCustomer
@Id UNIQUEIDENTIFIER
AS
UPDATE GuilhermeStore.Customer
SET IsDeleted = 1 WHERE Id = @Id
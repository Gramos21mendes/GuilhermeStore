CREATE LOGIN guilherme WITH PASSWORD = '340$Uuxwp7Mcxo7Khy'
,DEFAULT_DATABASE = [GuilhermeStore]
GO


USE GuilhermeStore;
CREATE USER guilherme FOR LOGIN guilherme;
EXEC sp_addrolemember 'db_datareader', 'guilherme'
EXEC sp_addrolemember 'db_datawriter', 'guilherme'
GO


--GRANT EXECUTE ON [dbo].[spCheckDocument] TO [guilherme] 
--GRANT EXECUTE ON[dbo].[spCheckEmail] TO [guilherme] 
--GRANT EXECUTE ON [dbo].[spCreateAdress]TO [guilherme] 
--GRANT EXECUTE ON[dbo].[spCreateCustomer] TO [guilherme] 
--GRANT EXECUTE ON [dbo].[spGetCustomerOrdersCount]TO [guilherme] 
--GRANT EXECUTE ON [dbo].[spListCustomer]TO [guilherme] 
--GRANT EXECUTE ON [dbo].[spListCustomerId]TO [guilherme] 
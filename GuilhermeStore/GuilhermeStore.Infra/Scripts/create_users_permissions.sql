CREATE LOGIN guilherme WITH PASSWORD = '340$Uuxwp7Mcxo7Khy'
,DEFAULT_DATABASE = [GuilhermeStore]
GO


USE GuilhermeStore;
CREATE USER guilherme FOR LOGIN guilherme;
EXEC sp_addrolemember 'db_owner', 'guilherme'
GO
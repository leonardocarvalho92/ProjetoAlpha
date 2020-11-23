IF NOT EXISTS (SELECT NAME FROM SYS.databases WHERE NAME='Alpha')
BEGIN
CREATE DATABASE Alpha;
END
GO
USE [Alpha]
GO
IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = 'users') 
BEGIN
CREATE TABLE users(
id int IDENTITY(1,1) PRIMARY KEY,
username varchar(30) NOT NULL,
name varchar(40)NOT NULL,
pswd varchar(300) NOT NULL
);
END
GO
IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = 'providers') 
BEGIN
CREATE TABLE providers(
id int IDENTITY(1,1) PRIMARY KEY,
name varchar(300) NOT NULL,
social_name varchar(300) NOT NULL,
cnpj varchar(300) NOT NULL,
adress varchar(300) NOT NULL,
phone varchar(14) NULL,
email varchar(300) NULL,
main_activity varchar(300) NULL,
active bit NOT NULL
);
END
GO
IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = 'products') 
BEGIN
CREATE TABLE products(
id int IDENTITY(1,1) PRIMARY KEY,
name varchar(300) NOT NULL,
provider_id int NOT NULL,
amount int NOT NULL,
FOREIGN KEY (provider_id) REFERENCES providers(id)
);
END
GO
/*----------------------------------*/
/*		CRIAÇAO DE USUARIO			*/
/*----------------------------------*/
IF NOT EXISTS(SELECT USERNAME FROM USERS WHERE USERNAME='supervisor')
BEGIN
INSERT INTO USERS 
VALUES
('supervisor','Supervisor Geral','$2a$12$4Jm0/uU2TPQnCtcO4NZhuu2bvKt42y4N21Vm75GWsgmJeGWBJY74y')
END
/*----------------------------------*/
/*		CRIAÇAO DAS VIEWS			*/
/*----------------------------------*/
GO
IF (NOT EXISTS(SELECT name FROM SYSOBJECTS WHERE name = 'view_show_products' AND type = 'V'))
BEGIN
	EXEC sp_executesql @statement =	N'
	CREATE VIEW view_show_products as
		SELECT products.id, 
			products.name, 
			products.amount , 
			providers.name as provider_name,
			providers.id as provider_id
		FROM products
			INNER JOIN providers ON products.provider_id = providers.id'
END
GO
IF (NOT EXISTS(SELECT name FROM SYSOBJECTS WHERE name = 'view_show_providers' AND type = 'V'))
BEGIN
	EXEC sp_executesql @statement =	N'
	create view view_show_providers as
		SELECT providers.id,
			providers.name, 
			providers.social_name, 
			providers.cnpj,
			providers.adress,
			providers.phone,
			providers.email,
			providers.main_activity,
			providers.active
		FROM providers'
END




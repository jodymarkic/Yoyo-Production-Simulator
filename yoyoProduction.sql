--
--	FILENAME: BI_A02_yoyoProduction
--	PROJECT: BI_A02
--	PROGRAMMER: Jody Markic
--	FIRST VERSION: 10/1/2017
--	DESCRIPTION: This file holds creating a database, table products and production, and seeding products with values
--
DROP DATABASE IF EXISTS yoyoProduction; -- drop table if exists

CREATE DATABASE yoyoProduction; -- create database

USE yoyoProduction; -- use database

--create table
CREATE TABLE Products (
    pProductID INT IDENTITY(1,1) PRIMARY KEY,
    pProductName VARCHAR(255),
);

--create table
CREATE TABLE Production (
    pProductionID BIGINT IDENTITY(1,1) PRIMARY KEY,
	pWorkArea VARCHAR(255),
	pSerialNumber VARCHAR(255),
	pLine VARCHAR(255),
	pState VARCHAR(255),
	pReason VARCHAR(255),
	pDateTime DATETIME,
	pProductID INT,
	FOREIGN KEY (pProductID)
	REFERENCES Products (pProductID)
);

--insert into products
INSERT INTO Products(pProductName) values('Original Sleeper'),('Black Beauty'),('Firecracker'),('Lemon Yellow'),('Midnight Blue'),('Screaming Orange'),('Gold Glitter'),('White Lightening');
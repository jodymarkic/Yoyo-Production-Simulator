DROP DATABASE IF EXISTS yoyoProduction;

CREATE DATABASE yoyoProduction;

USE yoyoProduction;

DROP TABLE Products;

CREATE TABLE Products (
    pProductID INT IDENTITY(1,1) PRIMARY KEY,
    pProductName VARCHAR(255),
);

DROP TABLE Production;

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

INSERT INTO Products(pProductName) values('Original Sleeper'),('Black Beauty'),('Firecracker'),('Lemon Yellow'),('Midnight Blue'),('Screaming Orange'),('Gold Glitter'),('White Lightening');

SELECT COUNT(pProductionID) FROM Production WHERE pState = 'MOLD'; -- 1.	 Total Mold  LABEL 1



SELECT COUNT(pProductionID) FROM Production WHERE pReason != '' AND  pState = 'INSPECTION_1_SCRAP'; -- 2.	Inspection_1_Scrap

--3.	 1. minus 2. do through C#  LABEL 2

-- 4.	 3. DIVIDED BY 1.  LABEL 3

SELECT COUNT(pProductionID) FROM Production WHERE pState = 'PAINT'; -- 5.	 paint

SELECT COUNT(pProductionID) FROM Production WHERE pState = 'INSPECTION_2_SCRAP' OR pState = 'INSPECTION_2_REWORK'; -- 6.	 INSPECTION_2_Rework + Inspection_2_Scrap


SELECT COUNT(pProductionID) FROM Production WHERE pState = 'ASSEMBLY';

SELECT COUNT(pProductionID) FROM Production WHERE pState = 'ASSEMBLY' AND pProductID = @productID;

SELECT COUNT(pProductionID) FROM Production WHERE pState = 'INSPECTION_3_SCRAP' OR pState = 'INSPECTION_3_REWORK';

SELECT COUNT(pProductionID) FROM Production WHERE (pState = 'INSPECTION_3_SCRAP' OR pState = 'INSPECTION_3_REWORK') AND pProductID = @productID;

SELECT COUNT(pProductionID) FROM Production WHERE pState = 'PACKAGE';

SELECT COUNT(pProductionID) FROM Production WHERE pState = 'PACKAGE' AND pProductID = @productID;

-- 6.	 5. MINUS 3 LABEL 4

-- 7.    5. DIVIDED BY 

SELECT COUNT(pProductionID) FROM Production WHERE pState = 'ASSEMBLY';


SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'FINAL_COAT_FLAW';
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'BROKEN_SHELL';
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'BROKEN_AXLE';
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'TANGLED_STRING';
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'PRIMER_DEFECT';
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'DRIP_MARK';
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'INCONSISTENT_THICKNESS';
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'WARPING';
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'PITTING';

SELECT * FROM Production;
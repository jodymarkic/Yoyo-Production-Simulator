--
--	FILENAME: BI_A02_StoredProcedures
--	PROJECT: BI_A02
--	PROGRAMMER: Jody Markic
--	FIRST VERSION: 10/1/2017
--	DESCRIPTION: This file holds all stored procedures used in the yoyoProduction database and BI_A02
--
USE yoyoProduction;
GO
CREATE PROCEDURE InsertToProduction
@workArea VARCHAR(255),
@serialNumber VARCHAR(255),
@line VARCHAR(255),
@state VARCHAR(255),
@reason VARCHAR(255),
@dateTime DATETIME,
@productID INT
AS
INSERT INTO Production (pWorkArea, pSerialNumber, pLine, pState, pReason, pDateTime, pProductID) VALUES
(@workArea, @serialNumber, @line, @state, @reason, @dateTime, @productID); 

--These are for report --
GO
CREATE PROCEDURE SelectAllTotalMold --all total mold

AS
SELECT COUNT(pProductionID) FROM Production WHERE pState = 'MOLD';

GO
CREATE PROCEDURE SelectSpecficTotalMold --specific total mold
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pState = 'MOLD' AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllInspectionScrapOne -- all inspection 1 scrap
AS
SELECT COUNT(pProductionID) FROM Production WHERE pState = 'INSPECTION_1_SCRAP';

GO
CREATE PROCEDURE SelectSpecificInspectionScrapONE -- specific inspection 1 scrap
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pState = 'INSPECTION_1_SCRAP' AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllTotalPaint -- all total paint
AS
SELECT COUNT(pProductionID) FROM Production WHERE pState = 'PAINT';

GO
CREATE PROCEDURE SelectSpecificTotalPaint -- spectic total paint
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pState = 'PAINT' AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllScrapAndReworkTwo
AS
SELECT COUNT(pProductionID) FROM Production WHERE pState = 'INSPECTION_2_SCRAP' OR pState = 'INSPECTION_2_REWORK';

GO
CREATE PROCEDURE SelectSpecificScrapAndReworkTWO
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE (pState = 'INSPECTION_2_SCRAP' OR pState = 'INSPECTION_2_REWORK') AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllTotalAssembly
AS
SELECT COUNT(pProductionID) FROM Production WHERE pState = 'ASSEMBLY';

GO
CREATE PROCEDURE SelectSpecificTotalAssembly
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pState = 'ASSEMBLY' AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllScrapAndReworkTHREE
AS
SELECT COUNT(pProductionID) FROM Production WHERE pState = 'INSPECTION_3_SCRAP' OR pState = 'INSPECTION_3_REWORK';

GO
CREATE PROCEDURE SelectSpecificScrapAndReworkTHREE
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE (pState = 'INSPECTION_3_SCRAP' OR pState = 'INSPECTION_3_REWORK') AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllTotalPackage
AS
SELECT COUNT(pProductionID) FROM Production WHERE pState = 'PACKAGE';

GO
CREATE PROCEDURE SelectSpecificTotalPackage
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pState = 'PACKAGE' AND pProductID = @productID;


--THESE ARE FOR PARETO DIAGRAM --
GO
CREATE PROCEDURE SelectAllFinalCoatFlaw
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'FINAL_COAT_FLAW';

GO
CREATE PROCEDURE SelectSpecificFinalCoatFlaw
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'FINAL_COAT_FLAW' AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllBrokenShell
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'BROKEN_SHELL';

GO
CREATE PROCEDURE SelectSpecificBrokenShell
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'BROKEN_SHELL' AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllBrokenAxle
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'BROKEN_AXLE';

GO
CREATE PROCEDURE SelectSpecificBrokenAxle
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'BROKEN_AXLE' AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllTangledString
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'TANGLED_STRING';

GO
CREATE PROCEDURE SelectSpecificTangledString
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'TANGLED_STRING' AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllPrimerDefect
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'PRIMER_DEFECT';

GO
CREATE PROCEDURE SelectSpecificPrimerDefect
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'PRIMER_DEFECT' AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllDripMark
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'DRIP_MARK';

GO
CREATE PROCEDURE SelectSpecificDripMark
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'DRIP_MARK' AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllInconsistentThickness
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'INCONSISTENT_THICKNESS';

GO
CREATE PROCEDURE SelectSpecificInconsistentThickness
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'INCONSISTENT_THICKNESS' AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllWarping
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'WARPING';

GO
CREATE PROCEDURE SelectSpecificWarping
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'WARPING' AND pProductID = @productID;

GO
CREATE PROCEDURE SelectAllPitting
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'PITTING';

GO
CREATE PROCEDURE SelectSpecificPitting
@productID INT
AS
SELECT COUNT(pProductionID) FROM Production WHERE pReason = 'PITTING' AND pProductID = @productID;

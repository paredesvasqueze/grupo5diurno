USE [Real_Music]
GO
/****** Object:  StoredProcedure [dbo].[USP_Insert_Pla]    Script Date: 3/10/2024 11:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[USP_Insert_Pla]
@cNombrePlan varchar(50),
@nCosto decimal(10,2),
@cDescripcion varchar(255)
as
BEGIN
INSERT INTO Pla
([cNombrePlan], [nCosto], [cDescripcion])
VALUES 
(@cNombrePlan, @nCosto, @cDescripcion)
select cast(SCOPE_IDENTITY() as int)
END
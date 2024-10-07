USE [Real_Music]
GO
/****** Object:  StoredProcedure [dbo].[USP_Actualizar_Pla]    Script Date: 3/10/2024 10:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[USP_Actualizar_Pla]
@nIdPlan int,
@cNombrePlan varchar(50),
@nCosto decimal(10,2),
@cDescripcion varchar(255)
AS
BEGIN
    UPDATE Pla SET
		nCosto = @cNombrePlan,
		cNombrePlan = @nCosto,
		cDescripcion = @cDescripcion
    WHERE nIdPlan = @nIdPlan;
	select cast(@@ROWCOUNT as int)
END
USE [Real_Music]
GO
/****** Object:  StoredProcedure [dbo].[USP_Eliminar_Pla]    Script Date: 3/10/2024 11:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[USP_Eliminar_Pla]
    @nIdPlan int
AS
BEGIN
    DELETE FROM Pla
    WHERE nIdPlan = @nIdPlan
	select cast(@@ROWCOUNT as int)
END
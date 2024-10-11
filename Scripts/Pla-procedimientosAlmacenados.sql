/*USP-PLA*/

/*PLA-SELECT*/
create PROCEDURE USP_Select_Pla_Todos
as
begin
select * from Pla
end
go

/*PLA-INSERT*/
create procedure USP_Insert_Pla
@cNombrePlan varchar(50),
@nCosto decimal(10,2),
@cDescripcion varchar(255)
as
BEGIN
INSERT INTO Pla
(cNombrePlan, nCosto, cDescripcion)
VALUES 
(@cNombrePlan, @nCosto, @cDescripcion)
select cast(SCOPE_IDENTITY() as int)
END
go

/*PLA-ACTUALIZAR*/
﻿create  procedure USP_Actualizar_Pla
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
go

/*PLA-ELIMINAR*/
create procedure USP_Eliminar_Pla
    @nIdPlan int
AS
BEGIN
    DELETE FROM Pla
    WHERE nIdPlan = @nIdPlan
	select cast(@@ROWCOUNT as int)
END
go
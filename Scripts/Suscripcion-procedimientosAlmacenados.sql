/*USP_ DE SUSCRIPCION*/

/*SUSCRIPCION-SELECT-TODOS*/
create procedure USP_Select_Suscripcion_Todos
as
begin
select * from Suscripcion
end	 
go

/*SUSCRIPCION-INSERT*/
create procedure USP_Insert_Suscripcion
@nIdUsuario int,
@nIdPlan int,
@dFechaInicio datetime,
@dFechaFin datetime
as
BEGIN
INSERT INTO Suscripcion
(nIdUsuario, nIdPlan, dFechaInicio, dFechaFin)
VALUES 
(@nIdUsuario, @nIdPlan, @dFechaInicio, @dFechaFin)
select cast(SCOPE_IDENTITY() as int)
END
go

/*SUSCRIPCION-ACTUALIZAR*/
create procedure USP_Actualizar_Suscripcion
@nIdSuscripcion int,
@nIdUsuario int,
@nIdPlan int,
@dFechaInicio datetime,
@dFechaFin datetime
AS
BEGIN
    UPDATE Suscripcion SET
		nIdUsuario = @nIdUsuario,
		nIdPlan = @nIdPlan,
		dFechaInicio = @dFechaInicio,
		dFechaFin = @dFechaFin
    WHERE nIdSuscripcion = @nIdSuscripcion;
	select cast(@@ROWCOUNT as int)
END
go

/*SUSCRIPCION-ELIMINAR*/
create procedure USP_Eliminar_Suscripcion
    @nIdSuscripcion int
AS
BEGIN
    DELETE FROM Suscripcion
    WHERE nIdSuscripcion = @nIdSuscripcion
	select cast(@@ROWCOUNT as int)
END
go
/*USP-USUARIO*/

/*USUARIO-SELECT-TODOS*/
create procedure USP_GET_Usuario_Todos
as
begin
select * from Usuario
end
GO

/*USUARIO-SELECT-ID*/
create procedure USP_Obtener_Usuario_Por_Id
@nIdUsuario INT
AS
BEGIN
    SELECT *
    FROM Usuario
    WHERE nIdUsuario = @nIdUsuario;
END; 
GO

/*USUARIO-INSERT*/
create procedure USP_Insert_Usuario
@cNombre VARCHAR(100),
@cEmail VARCHAR(150),
@cContrasenia VARCHAR(255),
@cTipoCuenta VARCHAR(50),
@nIdRol INT
AS
BEGIN
    INSERT INTO Usuario (cNombre, cEmail, cContrasenia, cTipoCuenta, nIdRol)
    VALUES (@cNombre, @cEmail, @cContrasenia, @cTipoCuenta, @nIdRol);

select cast(SCOPE_IDENTITY() as int)
END;
GO

/*USUARIO-ACTUALIZAR*/
create procedure USP_Actualizar_Usuario
@nIdUsuario INT,
@cNombre VARCHAR(100),
@cEmail VARCHAR(150),
@cContrasenia VARCHAR(255),
@cTipoCuenta VARCHAR(50),
@nIdRol INT
AS
BEGIN
UPDATE Usuario
SET 
cNombre = COALESCE(@cNombre, cNombre),
cEmail = COALESCE(@cEmail, cEmail),
cContrasenia = COALESCE(@cContrasenia, cContrasenia),
cTipoCuenta = COALESCE(@cTipoCuenta, cTipoCuenta),
nIdRol = COALESCE(@nIdRol, nIdRol)
WHERE nIdUsuario = @nIdUsuario;

select cast(@@ROWCOUNT as int) 
END;
GO

/*USUARIO-ELIMINAR*/
create procedure USP_Eliminar_Usuario
@nIdUsuario INT
AS
BEGIN
DELETE FROM Usuario WHERE nIdUsuario = @nIdUsuario;
select cast(@@ROWCOUNT as int) 
END;
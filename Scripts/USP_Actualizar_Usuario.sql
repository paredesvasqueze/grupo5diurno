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
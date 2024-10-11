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
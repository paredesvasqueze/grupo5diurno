create procedure USP_Eliminar_Usuario
@nIdUsuario INT
AS
BEGIN
    DELETE FROM Usuario WHERE nIdUsuario = @nIdUsuario;
	select cast(@@ROWCOUNT as int) 
END;
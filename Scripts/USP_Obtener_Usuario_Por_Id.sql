create procedure USP_Obtener_Usuario_Por_Id
@nIdUsuario INT
AS
BEGIN
    SELECT *
    FROM Usuario
    WHERE nIdUsuario = @nIdUsuario;
END; 
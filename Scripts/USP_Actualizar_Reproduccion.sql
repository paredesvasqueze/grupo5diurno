CREATE PROCEDURE USP_Actualizar_Reproduccion
    @nIdReproduccion INT,
    @nIdUsuario INT,
    @nIdCancion INT
AS
BEGIN
    UPDATE Reproduccion
    SET nIdUsuario = @nIdUsuario,
        nIdCancion = @nIdCancion
    WHERE nIdReproduccion = @nIdReproduccion;
END
GO
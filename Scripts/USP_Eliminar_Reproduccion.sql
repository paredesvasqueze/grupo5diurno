CREATE PROCEDURE USP_Eliminar_Reproduccion
    @nIdReproduccion INT
AS
BEGIN
    DELETE FROM Reproduccion
    WHERE nIdReproduccion = @nIdReproduccion;
END
GO

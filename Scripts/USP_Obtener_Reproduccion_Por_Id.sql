CREATE PROCEDURE USP_Obtener_Reproduccion_Por_Id
    @nIdReproduccion INT
AS
BEGIN
    SELECT *
    FROM Reproduccion
    WHERE nIdReproduccion = @nIdReproduccion;
END
GO

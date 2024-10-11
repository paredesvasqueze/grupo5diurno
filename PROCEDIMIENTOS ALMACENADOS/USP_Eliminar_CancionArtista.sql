CREATE PROCEDURE USP_Eliminar_CancionArtista
    @nIdCancion INT,
    @nIdArtista INT
AS
BEGIN
    DELETE FROM CancionArtista
    WHERE nIdCancion = @nIdCancion AND nIdArtista = @nIdArtista

    SELECT CAST(@@ROWCOUNT AS INT)
END
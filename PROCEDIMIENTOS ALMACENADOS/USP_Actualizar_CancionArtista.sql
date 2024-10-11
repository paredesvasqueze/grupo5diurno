CREATE PROCEDURE USP_Actualizar_CancionArtista
    @nIdCancion INT,
    @nIdArtista INT
AS
BEGIN
    UPDATE CancionArtista
    SET
        nIdArtista = @nIdArtista
    WHERE nIdCancion = @nIdCancion AND nIdArtista = @nIdArtista

    SELECT CAST(@@ROWCOUNT AS INT)
END

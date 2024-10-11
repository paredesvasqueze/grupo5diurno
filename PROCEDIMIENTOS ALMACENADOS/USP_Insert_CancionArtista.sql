CREATE PROCEDURE USP_Insert_CancionArtista
    @nIdCancion INT,
    @nIdArtista INT
AS
BEGIN
    INSERT INTO CancionArtista
        (nIdCancion, nIdArtista)
    VALUES
        (@nIdCancion, @nIdArtista)

    SELECT CAST(SCOPE_IDENTITY() AS INT)
END
CREATE PROCEDURE USP_Insert_PlaylistCancion
    @nIdPlaylist INT,
    @nIdCancion INT
AS
BEGIN
    INSERT INTO PlaylistCancion
        (nIdPlaylist, nIdCancion)
    VALUES
        (@nIdPlaylist, @nIdCancion)

    SELECT CAST(SCOPE_IDENTITY() AS INT)
END
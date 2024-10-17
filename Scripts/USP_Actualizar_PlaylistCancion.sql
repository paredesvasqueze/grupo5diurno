CREATE PROCEDURE USP_Actualizar_PlaylistCancion
    @nIdPlaylistCancion INT,
    @nIdPlaylist INT,
    @nIdCancion INT
AS
BEGIN
    UPDATE PlaylistCancion
    SET
        nIdPlaylist = @nIdPlaylist,
        nIdCancion = @nIdCancion
    WHERE nIdPlaylistCancion = @nIdPlaylistCancion

    SELECT CAST(@@ROWCOUNT AS INT)
END
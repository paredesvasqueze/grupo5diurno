CREATE PROCEDURE USP_Eliminar_PlaylistCancion
    @nIdPlaylistCancion INT
AS
BEGIN
    DELETE FROM PlaylistCancion
    WHERE nIdPlaylistCancion = @nIdPlaylistCancion

    SELECT CAST(@@ROWCOUNT AS INT)
END
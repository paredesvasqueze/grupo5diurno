ALTER proc USP_Eliminar_Artista (
@nIDArtista int
)
as
begin
delete from Artista
where nIdArtista = @nIdArtista
select cast(@@ROWCOUNT as int)
end
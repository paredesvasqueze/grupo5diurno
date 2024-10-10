ALTER proc USP_Actualizar_Artista
@nIDArtista int,
@cNombreArtista varchar(100)
as
begin
update Artista
set
cNombreArtista = @cNombreArtista
where nIdArtista = @nIDArtista

select cast(@@ROWCOUNT as int)
end

ALTER proc USP_Insert_Artista
@cNombreArtista varchar(100)
as
begin

insert into Artista
([cNombreArtista])
values
(@cNombreArtista)

select cast(SCOPE_IDENTITY() as int)
end
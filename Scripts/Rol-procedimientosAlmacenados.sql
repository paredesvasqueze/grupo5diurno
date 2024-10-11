/*PROCEDIMIENTOS ALMACENADOS DE ROL*/

/*ROL-SELECT*/
create procedure USP_GET_Rol_Todos
as
begin
select 
nIdRol,
cNombreRol
from Rol
end


/*ROL-INSERT*/
create procedure USP_Insert_Rol
@cNombreRol VARCHAR(50)
as
begin
insert into Rol
(cNombreRol)
values
(@cNombreRol)
select cast(SCOPE_IDENTITY() as int)
end


/*ROL-ACTUALIZAR*/
create procedure USP_Actualizar_Rol
@nIdRol INT,
@cNombreRol VARCHAR(50)
as
begin
update Rol
set 
cNombreRol=@cNombreRol
where nIdRol= @nIdRol
select cast(@@ROWCOUNT as int)
end


/*ROL-ELIMINAR*/
create procedure USP_Eliminar_Rol
@nIdRol INT
as
begin
delete from Rol where nIdRol=@nIdRol
select cast(@@ROWCOUNT as int)
end

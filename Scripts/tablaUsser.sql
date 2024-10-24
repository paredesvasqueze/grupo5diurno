create table usser
(
nIDUsser int primary key identity,
cUserName varchar(50),
cPassword varchar(256),
)
go
create proc ValidarUsuario
@cUserName varchar(50),
@cPassword varchar(256)
as
begin
if exists(select * from usser where 
cUserName = @cUserName and cPassword = @cPassword)
begin
select cast(1 as bit)
end
else
begin
select cast(0 as bit)
end
end
go
insert into usser 
(cUserName,cPassword)
values
('Juan','834C318F53AA0954D71F8AA0FA06D7C81B7F3376353AE2E2A20282C00DF4A1E0')
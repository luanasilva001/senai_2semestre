use T_Peoples;
go

select * from Funcionarios;
select * from tipoUsuario;
select * from Usuario;

select idTipoUsuario, tituloTipoUsuario from tipoUsuario;

select idUsuario, idTipoUsuario, email, senha from Usuario
where email = 'luana@adm.com' and senha = '123';

select tituloTipoUsuario, email, senha from Usuario
inner join tipoUsuario
on Usuario.idTipoUsuario = tipoUsuario.idTipoUsuario;
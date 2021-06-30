use T_Peoples;
go

insert into Funcionarios(nomeFuncionario, sobrenomeFuncionario, dataNascimento) 
values					('Catarina', 'Strada', ''),
						('Tadeu', 'Vitelli', '');
go

insert into Funcionarios (nomeFuncionario, sobrenomeFuncionario, dataNascimento)
values					 ('Luiza', 'Gerere', '11/12/1964');
go

insert into tipoUsuario (tituloTipoUsuario)
values					('Administrador')
					   ,('Comum')
go

insert into Usuario (idTipoUsuario, email, senha)
values				(1, 'luana@adm.com', '123')
				   ,(2, 'comum@comum.com', '123')


select * from Funcionarios
select nomeFuncionario, sobrenomeFuncionario, dataNascimento from Funcionarios;
CREATE DATABASE T_Peoples;
go 

USE T_Peoples;
go

CREATE TABLE Funcionarios
(
	idFuncionario int primary key identity
	,nomeFuncionario varchar (200) not null
	,sobrenomeFuncionario varchar (200) not null
	,dataNascimento date not null
);

create table tipoUsuario
(
	idTipoUsuario int primary key identity
	,tituloTipoUsuario varchar (200) unique not null
);
go

create table Usuario
(
	idUsuario int primary key identity
	,idTipoUsuario int foreign key references tipoUsuario(idTipoUsuario)
	,email varchar (150) unique not null
	,senha varchar (100) not null
);
go
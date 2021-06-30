-- Criar um banco de dados chamado inlock_games_tarde;
create database inlock_games_tarde;
go

use inlock_games_tarde;
go

-- Criar uma tabela de estúdios com os campos de idEstudio e nomeEstudio
create table estudios
(
	idEstudio int primary key identity
	,nomeEstudio varchar (200) not null 
);
go

-- Criar uma tabela de jogos com os campos idJogo, idEstudio, nomeJogo, descrição, dataLancamento e valor
create table jogos
(
	idJogo int primary key identity
	,idEstudio int foreign key references estudios(idEstudio)
	,nomeJogo varchar (250) not null
	,descricao varchar (250) not null
	,dataLancamento datetime not null
	,valor decimal not null
);
go

--Criar uma tabela de tipos de usuários contendo os campos idTipoUsuario e titulo
create table tipoUsuario
(
	idTipoUsuario int primary key identity
	,tituloTipoUsuario varchar (100) not null
);
go

-- Criar uma tabela de usuários contendo os campos de idUsuario, idTipoUsuario, email e senha
create table usuario
(
	idUsuario int primary key identity
	,idTipoUsuario int foreign key references tipoUsuario (idTipoUsuario)
	,email varchar (250) unique not null
	,senha varchar (250) not null
);
go
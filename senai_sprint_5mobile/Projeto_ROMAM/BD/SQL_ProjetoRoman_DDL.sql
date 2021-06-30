--DDL
--Criando o BD
Create database Projeto_Roman
Go

--Usando o BD
Use Projeto_Roman
Go

--Tabelas
Create table TipoUsuario (
	IdTipoUsuario Int primary key identity,
	TipoUsuario Varchar(200) Unique Not null

);
Go

Create Table Usuario (
	idUsuario int primary key identity
    ,idTipoUsuario int foreign key references TipoUsuario(IdTipoUsuario)
    ,email varchar (150) unique not null
	,NomeUsuario varchar(200) not null
    ,senha varchar (100) not null
);
Go

Create Table Tema (
	IdTema int primary key identity,
	TituloTema varchar(100) unique not null,
	idUsuario int foreign key references Usuario(idUsuario)
);
Go

Create Table Projeto (
	IdProjeto int primary key identity,
	IdTema int Foreign key references Tema(IdTema),
	Projeto varchar(200) Unique not null,
	idUsuario int foreign key references Usuario(idUsuario)
);
Go
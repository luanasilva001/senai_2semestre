create database hroads;
go

use hroads;
go

create table tipoUsuario
(
	idTipoUsuario int primary key identity
	,tituloTipoUsuario varchar (100) not null
);
go

create table usuario
(
	idUsuario int primary key identity
	,idTipoUsuario int foreign key references tipoUsuario (idTipoUsuario)
	,email varchar (250) unique not null
	,senha varchar (250) not null
);
go

create table Classe
(
	idClasse int primary key identity
	,nomeClasse varchar (40) not null
)
go

create table TipoHabilidade
(
	idTipoHabilidade int primary key identity
	,nomeTipoHabilidade varchar (40) not null
)

create table Personagem
(
	idPersonagem int primary key identity
	,nomePersonagem varchar (100) not null
	,capacidadeMaximaVida int not null
	,capacidadeMaximaMana int not null
	,dataAtualização date not null
	,dataDeCriacao date not null
	,idClasse int foreign key references Classe(idClasse)
)
go

create table Habilidade
(
	idHabilidade int primary key identity
	,nomeHabilidade varchar (100) not null
	,idTipoHabilidade int foreign key references tipoHabilidade (idTipoHabilidade)
)
go

create table ClasseHabilidade
(
	idClasse int foreign key references Classe(idClasse)
	,idHabilidade int foreign key references Habilidade(idHabilidade)
)
go
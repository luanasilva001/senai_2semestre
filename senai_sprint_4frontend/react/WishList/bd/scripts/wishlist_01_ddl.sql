--DDl

--Criar o BD 
Create database Projeto_WishList
Go

--usar o BD
use Projeto_WishList
Go

--Criar Tabelas
Create Table Usuarios (
	IdUsuario Int Primary key identity,
	Email varchar(100) UNIQUE Not null,
	Senha Varchar(80) NOT NULL,
);
Go

Create Table ListaDesejos (
 IdDesejo int primary key identity,
 IdUsuario int foreign key references Usuarios(IdUsuario),
 Descricaodesejo varchar(250) Unique Not Null,
);
Go
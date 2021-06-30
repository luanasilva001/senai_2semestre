create database micromanu;

use micromanu;

create table Empresa
(
	idEmpresa int primary key identity
	,nomeEmpresa varchar (50) not null
	,CNPJEmpresa char (18) not null
	,enderecoEmpresa varchar (40) not null
	,telefoneEmpresa varchar (15) not null
	,siteEmpresa varchar (100) not null
);

create table Colaboradores 
(
	idColaborador int primary key identity
	,idEmpresa int foreign key references Empresa(idEmpresa)
	,nomeColaborador varchar (50) not null
	,salarioColaborador money not null
);

create table Cliente
(
	idCliente int primary key identity 
	,nomeCliente varchar (50) not null
	,telefoneCliente varchar (15) not null
	,emailCliente varchar (50) not null
);

create table Equipamento
(
	idEquipamento int primary key identity
	,idCliente int foreign key references Cliente(idCliente)
	,nomeEquipamento varchar (50) not null
);

create table Atendimento
(
	idAtendimento int primary key identity
	,idEquipamento int foreign key references Equipamento(idEquipamento)
	,idColaborador int foreign key references Colaboradores(idColaborador)
	,horaAtendimento time not null
	,problemaEquipamento varchar (150) not null
	,dataAtendimento date not null
);

create table ColaboradorAtendimento
(
	idColaborador int foreign key references Colaboradores(idColaborador)
	,idAtendimento int foreign key references Atendimento (idAtendimento)
);



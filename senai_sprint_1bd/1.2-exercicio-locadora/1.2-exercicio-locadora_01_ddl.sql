Create database Locadora;

Use Locadora;

Create table Empresas
(
	idEmpresa int primary key identity
	,nomeEmpresa varchar (100) not null
	,CNPJ char(18) not null
	,funcionariosEmpresa varchar (100) not null
	,enderecoEmpresa varchar (150) not null 
);

Create table Marcas
(
	idMarca int primary key identity
	,nomeMarca varchar (50) not null
	,sloganMarca varchar (100)
);

Create table Modelos
(
	idModelo int primary key identity
	,nomeModelo varchar (50) not null
	,tipoModelo varchar (100) not null
	,idMarca int foreign key REFERENCES Marcas(idMarca)
);

Create table Veiculos
(
	 idVeiculo int primary key identity
	,idEmpresa int foreign key REFERENCES Empresas(idEmpresa)
	,idModelo int foreign key REFERENCES Modelos(idModelo)
	,placaVeiculo varchar (7) not null
	,corVeiculo varchar (20) not null
);

create table Cliente(
	idCliente int primary key identity
	,nomeCliente varchar (100) not null
	,cnhCliente varchar (10) not null
	,idadeCliente char (2) not null
	,telefoneCliente varchar (15) not null
);

create table Aluguel
(
	idAluguel int primary key identity
	,idCliente int foreign key references Cliente(idCliente)
	,idVeiculo int foreign key references Veiculos(idVeiculo)
	,horaAluguel time not null
	,dataPegado date not null
	,dataDevolucao date not null
	,precoAluguel money not null
);


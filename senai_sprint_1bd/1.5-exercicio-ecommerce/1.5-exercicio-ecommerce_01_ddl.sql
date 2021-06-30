create database ECOMMERCE;

use ECOMMERCE;

create table Loja
(
	idLoja int primary key identity
	,nomeLoja varchar (50) not null
	,enderecoLoja varchar (100) not null
	,telefoneLoja varchar (15) not null
	,cnpj char (18) not null
);

create table Categoria 
(
	idCategoria int primary key identity
	,idLoja int foreign key references Loja(idLoja)
	,nomeCategoria varchar (30) not null
);

create table SubCategoria
(
	idSubCategoria int primary key identity
	,idCategoria int foreign key references Categoria(idCategoria)
	,nomeSubCategoria varchar (50) not null
);

create table Cliente
(
	idCliente int primary key identity
	,nomeCliente varchar (100) not null
	,RGCliente char (9) not null
	,telefoneCliente varchar (15) not null
	,CPFCliente char (14) not null
);

create table Pedido 
(
	idPedido int primary key identity
	,idCliente int foreign key references Cliente(idCliente)
	,qtdPedido int not null
	,notaFiscal char (10) not null
);

create table Produto
(
	idProduto int primary key identity
	,idSubCategoria int foreign key references SubCategoria(idSubCategoria)
	,idPedido int foreign key references Pedido(idPedido)
	,nomeProduto varchar (100) not null
	,precoProduto money not null
	,validadeProduto varchar (20) not null
);

create table PedidoProduto
(
	idPedido int foreign key references Pedido(idPedido)
	,idProduto int foreign key references Produto(idProduto)
);
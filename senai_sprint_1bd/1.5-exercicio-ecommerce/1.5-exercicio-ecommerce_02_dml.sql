use ECOMMERCE;

insert into Loja (nomeLoja, enderecoLoja, telefoneLoja, cnpj)
VALUES ('Magazine Luiza', 'R. Limao, 98', '(11) 94876-5443', 'XX.XXX.XXX/0001-XX'),
	   ('Casas Bahia', 'R. Paçoca, 229', '(11)92345-6789', 'XX.XXX.XXX/0002-XX');

insert into Categoria (nomeCategoria, idLoja)
values ('Higiene', 2), ('Açougue', 1);

insert into SubCategoria  (nomeSubCategoria, idCategoria)
values ('Salsicha', 2), ('Creme facial', 1);

insert into Cliente (nomeCliente, RGCliente, CPFCliente, telefoneCliente)
values ('Luana', '1234567-8', '000.000.000-01', '(11)99999-9999'),
	   ('Carolina', '1235678-3', '000.000.000-22', '(11) 91234-5678');

insert into Pedido (qtdPedido, notaFiscal, idCliente)
values (28, '00000000-9', 1),
		(2,	'22222222-0', 2);

insert into Produto (nomeProduto, precoProduto, validadeProduto, idSubCategoria, idPedido)
values ('Salsicha HotDog', '10.00', '10/01/2021', 1, 1),
	   ('Sabonete liquído', '6.64', '12/01/2022', 2, 2);

insert into PedidoProduto (idPedido, idProduto)
					   values (1, 1), 
							  (2, 2);
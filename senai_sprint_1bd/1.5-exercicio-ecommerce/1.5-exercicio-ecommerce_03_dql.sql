use ECOMMERCE;

select * from Loja;
select * from Categoria;
select * from SubCategoria;
select * from Cliente;
select * from Pedido;
select * from Produto;
select * from PedidoProduto;

select Cliente.nomeCliente, Produto.nomeProduto, SubCategoria.nomeSubCategoria, Categoria.nomeCategoria, Pedido.qtdPedido from Pedido
inner join Cliente
on Pedido.idCliente = Cliente.idCliente
inner join PedidoProduto 
on PedidoProduto.idPedido = Pedido.idPedido
inner join Produto
on PedidoProduto.idProduto = Produto.idProduto
inner join SubCategoria
on Produto.idSubCategoria = SubCategoria.idSubCategoria
inner join Categoria
on Produto.idSubCategoria = Categoria.idCategoria
where Cliente.nomeCliente like 'Carolina';
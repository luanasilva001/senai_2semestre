use Locadora;

select * from Empresas;
select * from Marcas;
select * from Modelos;
select * from Veiculos;
select * from Cliente;



--inner join--
select * from Aluguel;

select Aluguel.dataPegado, Aluguel.dataDevolucao, Cliente.nomeCliente, Modelos.nomeModelo from Aluguel
inner join Cliente
on Cliente.idCliente = Aluguel.idCliente
inner join Veiculos
on Aluguel.idVeiculo = Veiculos.idVeiculo
inner join Modelos
on Modelos.idModelo = Veiculos.idModelo;

select Aluguel.dataPegado, Aluguel.dataDevolucao, Cliente.nomeCliente, Modelos.nomeModelo from Aluguel
inner join Cliente
on Cliente.idCliente = Aluguel.idCliente
inner join Veiculos
on Aluguel.idVeiculo = Veiculos.idVeiculo
inner join Modelos
on Modelos.idModelo = Veiculos.idModelo
where Cliente.nomeCliente like 'Luana';
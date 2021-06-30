use micromanu;

select * from Empresa;
select * from Cliente;
select * from Colaboradores;
select * from Equipamento;
select * from Atendimento;
select * from ColaboradorAtendimento;

select Cliente.nomeCliente, Equipamento.nomeEquipamento from Cliente
inner join Equipamento
on Equipamento.idCliente = Cliente.idCliente;

select Cliente.nomeCliente, Colaboradores.nomeColaborador, Atendimento.problemaEquipamento,
Equipamento.nomeEquipamento from ColaboradorAtendimento
inner join Atendimento
on ColaboradorAtendimento.idAtendimento = Atendimento.idAtendimento
inner join Equipamento
on Atendimento.idEquipamento = Equipamento.idEquipamento
inner join Cliente
on Equipamento.idCliente = Cliente.idCliente
inner join Colaboradores
on ColaboradorAtendimento.idColaborador = Colaboradores.idColaborador;

update Cliente
set nomeCliente = 'Regis'
Where idCliente = 1;

update Cliente
set nomeCliente = 'Marcos'
Where idCliente = 1;

update Cliente
set nomeCliente = 'Duda'
Where idCliente = 1;

update Cliente
set nomeCliente = 'João'
Where idCliente = 1;

update Cliente
set nomeCliente = 'Caique'
Where idCliente = 1;

delete from Cliente
where idCliente = 2;

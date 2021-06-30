use micromanu;

insert into Empresa (nomeEmpresa, CNPJEmpresa, enderecoEmpresa, telefoneEmpresa, siteEmpresa)
values ('MicroManu', 'XX.XXX.XXX/0001-XX', 
		'R. Barão de Limeira, 293', 
		'(11) 99999-9999', 'www.micromanu.com');

insert into Cliente (nomeCliente, telefoneCliente, emailCliente)
values ('Luana', '(11) 99999-9999', 'luana@gmail.com'),
	   ('Luiza', '(11) 98454-5939', 'luizinha@yahoo.com');

insert into Colaboradores (nomeColaborador, salarioColaborador, idEmpresa)
values ('Erick', 950.90, 1),
	   ('Daniel', 700.43, 1),
	   ('João', 1.203, 1);

insert into Equipamento (nomeEquipamento, idCliente)
values ('Notebook', 1),
	   ('Ipad', 2);

insert into Atendimento (horaAtendimento, problemaEquipamento, dataAtendimento, idEquipamento, idColaborador)
values ('07:33', 'Notebook não liga mais', '27/01/2021', 1, 3),
	   ('16:30', 'IPad não corresponde ao touch', '24/02/2021', 2, 1);

insert into ColaboradorAtendimento (idColaborador, idAtendimento)
values (3, 1),
	   (1, 2);
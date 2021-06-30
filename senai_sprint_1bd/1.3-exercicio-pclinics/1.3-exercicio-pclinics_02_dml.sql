use PCCLINICS;

insert into Clinica (enderecoClinica, nomeClinica, telefoneClinica)
values ('R.Arroz Doce, 48', 'Amor ao Pet', '(11) 94567-8988'),
	   ('R.Goiabada, 87', 'Clinica do amor', '(11) 94567-7626');

insert into Veterinario (nomeVeterinario, crmVeterinario, idadeVeterinario, idClinica)
values ('Lais', 'A054008', '38', 1),
	   ('Tonia', 'A054007', '25', 2);

insert into Dono (nomeDono, idadeDono, telefoneDono)
values ('Luiza', '57', '(11) 98765-4738'),
	   ('Mauricio', '23', '(11) 94729-8382');

insert into TipoPet (tipoPet)
values ('Cachorro'), 
	   ('Gato'),
	   ('Hamster');

insert into Raca (nomeRaca, idTipoPet)
values ('Pinscher', 1),
	   ('Hamster', 3),
	   ('Shitzu', 1);

insert into Pet (nomePet, dataNascimento, idDono, idRaca)
values ('Lilica', '01/06/2013', 1, 1),
	   ('Meg', '07/07/2019', 2, 2);

insert into Atendimento (horaAtendimento, fichaCadastroPet, dataAtendimento, idPet, idVeterinario)
values ('7:30', 'Infecção de ouvido', '24/02/2021', 1, 2),
	   ('16:43', 'Infecção urinária', '23/09/2020', 2, 1);
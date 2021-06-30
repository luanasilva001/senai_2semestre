-- DML --

use Pessoa;

insert into Pessoa (nomePessoa, dataNascimento,
cpf, rg) values ('Maria', '14/04/1964', '111.222.333-55', '12345678-9'),
				('Saulo', '19/09/1992', '000.495.999-89', '12348596-8'),
				('João', '21/10/2002', '999.333.555-10', '34567898-0');

insert into TelefonePessoa (numeroTelefone, operadoraTelefone, idPessoa)
values ('945676859', 'Oi', 3), 
	   ('956784356', 'Claro', 2),
	   ('987564323', 'Tim', 1);

insert into EmailPessoa (email, idPessoa)
values ('marialinda@gmail.com', 1), 
	   ('saulofadamarvel@yahoo.com', 2),
	   ('joaolindo@outlook.com', 3);

insert into CNHPessoa (fotoCNH, numeroRegistroCNH, idPessoa)
values ('123.png', '1234567891-9', 1),
	   ('456.png', '1234567812-9', 2),
	   ('789.png', '3334567891-9', 3);


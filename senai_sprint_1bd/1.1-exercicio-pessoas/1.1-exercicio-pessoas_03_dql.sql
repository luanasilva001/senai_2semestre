-- DQL --

use Pessoa;

select * from Pessoa
inner join TelefonePessoa
on Pessoa.idPessoa = TelefonePessoa.idPessoa
inner join EmailPessoa
on Pessoa.idPessoa = EmailPessoa.idPessoa
inner join CNHPessoa 
on Pessoa.idPessoa = CNHPessoa.idPessoa
order by Pessoa.nomePessoa desc;

select * from TelefonePessoa;
select * from EmailPessoa;
select * from CNHPessoa;

update Pessoa 
set nomePessoa = 'Eduarda'
where idPessoa = 1;

delete from Pessoa
where idPessoa = 1;

insert into EmailPessoa(email) values
			   ('dudalinda@gmail.com');

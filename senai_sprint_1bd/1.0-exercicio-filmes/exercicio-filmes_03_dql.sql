--DQL--

use Filmes;

select idGenero, nomeGenero from Generos;
select idFilme, tituloFilme, idGenero from Filmes;
select * from Generos;
select * from Filmes;

-- INER JOIN --
-- ALIAS (AS) --
select * from Filmes
inner join Generos
on Filmes.idGenero = Generos.idGenero;

--Left join --
select Filmes.tituloFilme, Generos.nomeGenero from Filmes
left join Generos
on Filmes.idGenero = Generos.idGenero;

select Filmes.tituloFilme, Generos.nomeGenero from Filmes
right join Generos
on Filmes.idGenero = Generos.idGenero;

select Filmes.tituloFilme, Generos.nomeGenero from Filmes
full outer join Generos
on Filmes.idGenero = Generos.idGenero;

Update Filmes
set tituloFilme = 'Rampage'
where idFilme = 2;

delete from Filmes
where idFilme = 2;

insert into Generos values ('Humor');

-- * = TUDO (ALL)
select * from Usuarios;

-- Busca um usuário através do e-mail e senha
select idUsuario, email, senha, permissao from Usuarios
where email = 'adm@adm.com' and senha = '123';
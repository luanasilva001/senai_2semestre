--DQL

--Usando BD
use Projeto_Roman
GO

Select * From Usuario
select * from Tema
select * from Projeto
select * from TipoUsuario


select nomeUsuario, TituloTema, Projeto as P from Projeto
inner join Usuario
on Projeto.idUsuario = Usuario.idUsuario
inner join Tema
on Projeto.IdTema = Tema.IdTema

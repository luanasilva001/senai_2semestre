use hroads;

--selecionar todas as classes
select * from Classe;

select * from tipoUsuario;

select * from Usuario;

select tituloTipoUsuario, email from usuario
inner join tipoUsuario
on usuario.idTipoUsuario = tipoUsuario.idTipoUsuario;

--selecionar somente o nome das classes
select Classe.nomeClasse from Classe;

--selecionar todos os personagens
select * from Personagem;

--selecionar todas as habilidades
select * from Habilidade;

--realizar a contagem de quantas habilidade estão cadastradas
select * from Habilidade
select count (idHabilidade) quantidadeDeHabilidadesCadastradas from Habilidade;

--selecionar somente os id’s das habilidades classificando-os por ordem crescente
select Habilidade.idHabilidade from Habilidade
order by Habilidade.idHabilidade;

--selecionar todos os tipos de habilidades
select * from TipoHabilidade;

--selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte
select Habilidade.nomeHabilidade, TipoHabilidade.nomeTipoHabilidade from Habilidade
inner join TipoHabilidade
on Habilidade.idTipoHabilidade = TipoHabilidade.idTipoHabilidade;

--selecionar todos os personagens e suas respectivas classes
select Personagem.nomePersonagem, Classe.nomeClasse from Personagem
inner join Classe
on Personagem.idClasse = Classe.idClasse;

--selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens)
select Personagem.nomePersonagem, Classe.nomeClasse from Classe
left join Personagem
on Personagem.idClasse = Classe.idClasse;

--Selecionar todas as classes e suas respectivas habilidades
select Classe.nomeClasse, Habilidade.nomeHabilidade from ClasseHabilidade 
inner join Classe
on  ClasseHabilidade.idClasse = Classe.idClasse
inner join Habilidade
on ClasseHabilidade.idHabilidade = Habilidade.idHabilidade;

--Selecionar todas as habilidades e suas classes(somente as que possuem correspondência)
select  Habilidade.nomeHabilidade, Classe.nomeClasse from Habilidade
inner join ClasseHabilidade
on Habilidade.idHabilidade = ClasseHabilidade.idHabilidade
inner join Classe
on Classe.idClasse = ClasseHabilidade.idClasse

--Selecionar todas as habilidades e suas classes (mesmo que elas nao tenham correspondencia)
select Habilidade.nomeHabilidade, Classe.nomeClasse from Habilidade
full outer join ClasseHabilidade
on Habilidade.idHabilidade = ClasseHabilidade.idHabilidade
full outer join Classe
on Classe.idClasse = ClasseHabilidade.idClasse
use inlock_games_tarde;
go

--Listar todos os usu�rios
select * from usuario;

-- Listar todos os est�dios
select * from estudios;

-- Listar todos os jogos
select * from jogos;

-- Listar todos os jogos e seus respectivos est�dios
select nomeEstudio, nomeJogo from jogos
inner join estudios
on jogos.idEstudio = estudios.idEstudio; 

-- Buscar e trazer na lista todos os est�dios com os respectivos jogos. Obs.: Listar todos os est�dios mesmo que eles n�o contenham nenhum jogo de refer�ncia
select idJogo, nomeJogo, descricao, dataLancamento, valor ,nomeEstudio from estudios
inner join jogos
on jogos.idEstudio = estudios.idEstudio

-- Buscar e trazer na lista todos os est�dios com os respectivos jogos. Obs.: Listar todos os est�dios mesmo que eles n�o contenham nenhum jogo de refer�ncia
select idJogo, nomeJogo, descricao, dataLancamento, valor ,nomeEstudio from estudios
left join jogos
on jogos.idEstudio = estudios.idEstudio

-- Buscar um usu�rio por e-mail e senha (login)
select idUsuario, idTipoUsuario, email, senha from usuario
where email = 'admin@admin.com' and senha = 'admin';

-- Buscar um jogo por idJogo
select nomeJogo from jogos
where idJogo = 1;

select * from jogos
where idEstudio = 2

-- Buscar um est�dio por idEstudio
select nomeEstudio from estudios
where idEstudio = 1;

select idJogo, estudios.idEstudio, nomeJogo, descricao, dataLancamento, valor, nomeEstudio from estudios
inner join jogos 
on jogos.idEstudio = estudios.idEstudio
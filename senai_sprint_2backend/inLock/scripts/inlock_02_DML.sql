use inlock_games_tarde;
go

-- Inserir um usuário do tipo ADMINISTRADOR 
-- Inserir um usuário do tipo CLIENTE 
insert into tipoUsuario (tituloTipoUsuario) 
values					('administrador')
						,('cliente')
go

-- Inserir um usuário do tipo ADMINISTRADOR que tenha o e-mail igual a admin@admin.com e a senha igual a admin
-- Inserir um usuário do tipo CLIENTE que tenha o e-mail igual a cliente@cliente.com e a senha igual a cliente
insert into usuario (idTipoUsuario, email, senha)
values				(1, 'admin@admin.com', 'admin')
				   ,(2, 'cliente@cliente.com', 'cliente')
go

-- Inserir três estúdios: um com o nome de Blizzard, outro com o nome de Rockstar Studios e o último com o nome de Square Enix;
insert into estudios (nomeEstudio)
values				 ('Blizzard')	
					,('Rockstar Studios')
					,('Square Enix')
go

-- Inserir um jogo com o nome de: Diablo 3, com data de lançamento de: 15 de maio de 2012, que contenha a descrição de: 
-- é um jogo que contém bastante ação 
-- e é viciante, seja você um novato ou um fã. Seu estúdio é a Blizzard. E o jogo custa R$ 99,00;

-- Inserir um jogo com o nome de: Red Dead Redemption II, com a descrição de: jogo
-- eletrônico de ação-aventura western. Seu estúdio será a Rockstar Studios. Lançado
-- mundialmente em 26 de outubro de 2018. E o jogo custa R$ 120,00;
insert into jogos (nomeJogo, dataLancamento, descricao, idEstudio, valor)
values			  ('Diablo 3', '15/05/2012', 'é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', 1, 99.00)
				 ,('Red Dead Redemption II', '26/10/2018', 'jogo eletrônico de ação-aventura western.', 2, 120.00)
go


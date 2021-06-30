--DML

--Usando O BD
use Projeto_Roman
Go

Insert into TipoUsuario(TipoUsuario)
values               ('professor');
Go

Insert into Usuario(IdTipoUsuario,email,senha,NomeUsuario)
values				(1,'saulo@gmail.com','123','Saulo'),
					(1,'Caique@gamil.com','123','CaiqueKirilo'),
					(1,'Thiago@gmail.com','123','nascimento'),
					(1,'Roberto@gmail.com','123','Possarle'),
					(1,'Paulo@gmail.com','123','PauloBrandão')            
Go

insert into Tema (TituloTema, idUsuario) 
values					('Gestão', 1)
					   ,('LGPD',   2)
					   ,('Desenvolvimento Web', 3)
go

insert into Projeto (IdTema, idUsuario, Projeto)
values				(1, 1, 'Projeto de Controle de Estoque')
				   ,(2, 2, 'Lei a favor da segurança dos consumidores')
				   ,(3, 3, 'Qual linguagem Web está mais em alta?')




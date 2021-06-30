--DML--

use Filmes;
go

insert into Generos values ('Gore'), 
						   ('Romance');
go

insert into Filmes values (1, 'Climax'), 
						  (2, 'Um amor pra recordar'), 
						  (1, 'Anticristo');
go

insert into Usuarios(email, senha, permissao)
values				('saulo@email.com', '123', 'comum')
				   ,('adm@adm.com', '123', 'administrador');
go
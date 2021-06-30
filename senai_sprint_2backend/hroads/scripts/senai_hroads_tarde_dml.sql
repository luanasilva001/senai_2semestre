use hroads;
go

insert into tipoUsuario (tituloTipoUsuario) 
values 
						('Administrador')
						,('Jogador')
go

insert into usuario (idTipoUsuario, email, senha)
values				(1, 'adm@adm.com', '123adm')
				   ,(2, 'jogador@jogador.com', '123jogador')
				   ,(2, 'jogador2@jogador2.com', '123jogador')
go
				   
insert into Classe(nomeClasse)
values            ('barbaro')
                 ,('cacadoraDeDemonio')
				 ,('monge')
				 ,('necromante')
				 ,('arcanismo')
				 ,('feiticeiro')
				 ,('cruzado');
go

insert into TipoHabilidade(nomeTipoHabilidade)
values                    ('ataque') 
                         ,('defesa')
						 ,('cura')
						 ,('magia');
go

insert into Personagem(nomePersonagem, capacidadeMaximaVida, capacidadeMaximaMana,dataAtualização, dataDeCriacao, idClasse, idUsuario)
values                ('DeuBug', '100', '80', '01/03/2021', '18/01/2019', 1, 2)
                     ,('BitBug', '70', '100', '01/03/2021', '17/03/2016', 3, 2)
					 ,('Fer8', '75', '60', '01/03/2021', '18/03/2018', 5, 3)
					 ,('DudaLinda', '80', '50', '01/03/2021', '20/01/2016', 2, 3)
					 ,('LuanaSilva001', '100', '80', '01/03/2021', '12/02/2015', 6, 2)
					 ,('AlanCabelao', '90', '60', '01/03/2021', '25/05/2016', 4, 3)
					 ,('StrilicherkBombado', '70', '80', '01/03/2021', '18/01/2015', 7, 2);
go

insert into Personagem(nomePersonagem, capacidadeMaximaVida, capacidadeMaximaMana,dataAtualização, dataDeCriacao, idClasse)
values                ('DeuBug', '100', '80', '01/03/2021', '18/01/2019', 1)
                     ,('BitBug', '70', '100', '01/03/2021', '17/03/2016', 3)
					 ,('Fer8', '75', '60', '01/03/2021', '18/03/2018', 5)
					 ,('DudaLinda', '80', '50', '01/03/2021', '20/01/2016', 2)
					 ,('LuanaSilva001', '100', '80', '01/03/2021', '12/02/2015', 6)
					 ,('AlanCabelao', '90', '60', '01/03/2021', '25/05/2016', 4)
					 ,('StrilicherkBombado', '70', '80', '01/03/2021', '18/01/2015', 7);
go

insert into Habilidade(nomeHabilidade, idTipoHabilidade)
values                ('lancaMortal', 1 )
                     ,('escudoSupremo', 2)
					 ,('recuperarVida', 3);
go

insert into ClasseHabilidade(idClasse, idHabilidade)
values                     (1, 1)
                          ,(1, 2)
						  ,(2, 1)
						  ,(3, 3)
						  ,(3, 2)
						  ,(6, 3)
						  ,(7, 2);
go

Update Personagem 
Set nomePersonagem = 'Fer7'
Where idClasse= 3;
go

Update Classe 
Set nomeClasse = 'Necromancer'
Where idClasse= 5;
go
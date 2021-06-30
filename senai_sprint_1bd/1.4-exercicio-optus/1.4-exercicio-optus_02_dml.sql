use OPTUS;

insert into Usuario (nomeUsuario, email, senha, tipoPermissao)
values ('Luana', 'luana@gmail.com', '123456', 'admin'),
	   ('José', 'josegato@yahoo.com', '654321', 'comum');

insert into Artista (nomeArtista)
values ('Katy Perry'), ('Anitta'),
	   ('Slipknot');

insert into Estilo (nomeEstilo)
values ('Pop'), 
	   ('Funk'),
	   ('Rock');

insert into Album (tituloAlbum, dataLancamentoAlbum, localizacaoAlbum, qtdMntAlbum, albumAtivoOuNao, idEstilo, idArtista)
values ('Smile', '28/08/2020', 'EUA', '36:00', 'Ativo', 1, 1),
	   ('Bang', '13/10/2015', 'Brasil', '42:00', 'Ativo', 2, 2),
	   ('Slipknot', '29/06/1999', 'California', '60:28', 'Ativo', 3, 3);

insert into AlbumEstilo 
values (2, 2),
	   (2, 1);

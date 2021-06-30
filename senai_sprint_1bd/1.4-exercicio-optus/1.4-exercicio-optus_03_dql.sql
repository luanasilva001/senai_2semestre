use OPTUS;

select * from Usuario;
select * from Artista;
select * from Estilo;
select * from Album;
select * from AlbumEstilo;

select Usuario.nomeUsuario, Usuario.tipoPermissao from Usuario;
select Album.dataLancamentoAlbum, Album.tituloAlbum from Album where Album.dataLancamentoAlbum > '2015';
select Usuario.nomeUsuario, Usuario.senha from Usuario;

select Album.albumAtivoOuNao, Artista.nomeArtista, Estilo.nomeEstilo from Album
inner join Artista
on Album.idArtista = Artista.idArtista
inner join Estilo
on Album.idEstilo = Estilo.idEstilo;

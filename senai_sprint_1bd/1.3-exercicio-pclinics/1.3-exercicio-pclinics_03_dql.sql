use PCCLINICS;

select * from Clinica;
select * from Veterinario;
select * from Dono;
select * from TipoPet;
select * from Raca;
select * from Pet;
select * from Atendimento;
 
select nomeVeterinario, crmVeterinario, Clinica.nomeClinica  from Veterinario 
inner join Clinica 
on Clinica.idClinica = Veterinario.idClinica
WHERE nomeClinica like 'Amor ao Pet';

select tipoPet from TipoPet WHERE tipoPet like '%_o';
select nomeRaca from Raca where nomeRaca like 'S_%';

select Pet.nomePet,Dono.nomeDono 
from Pet
inner join Dono
on Pet.idDono = Dono.idDono;

select Atendimento.idVeterinario, Veterinario.nomeVeterinario, Raca.nomeRaca, Pet.nomePet, Dono.nomeDono, Clinica.nomeClinica from Atendimento
inner join Veterinario 
on Atendimento.idVeterinario = Veterinario.idVeterinario
inner join Pet
on Atendimento.idPet = Pet.idPet
inner join Raca 
on Raca.idRaca = Pet.idRaca
inner join Dono
on Dono.idDono = Pet.idDono
inner join Clinica
on Clinica.idClinica = Veterinario.idClinica;
CREATE TABLE tutor_bees(
Calificar int,
Materia varchar (64) constraint mat_tu_nn not null
);
-- alter table tutor_bees add constraint usuario_tu_fk foreign key(ID_Usuario) references usuarios_bees(ID_Usuario);
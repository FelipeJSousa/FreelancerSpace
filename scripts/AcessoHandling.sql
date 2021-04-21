INSERT INTO Grupo(Nome, Descricao)
VALUES ('Grupo 1', 'Grupo de testes')

Insert into Acesso (IdFuncionalidade, IdGrupo, IdPermissao)
VALUES (1, 1, 2)

Select ace.Id Acesso_Id, gru.Nome Grupo, fun.Nome Funcionalidade, per.Nome Permissao from Acesso ace
inner join Grupo gru on ace.IdGrupo = gru.Id
inner join Funcionalidades fun on ace.IdFuncionalidade = fun.Id
inner join Permissao per on ace.IdPermissao = per.Id


Select Gru.nome Grupo, fun.Nome Funcionalidade, STRING_AGG(per.Nome, ' - ') Permissao from Grupo gru 
inner join Acesso ace on ace.IdGrupo = gru.Id
inner join Funcionalidades fun on ace.IdFuncionalidade = fun.Id
inner join Permissao per on ace.IdPermissao = per.Id
Where gru.id = 1
group by gru.Nome, fun.Nome
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (1,'CONJUNTO','CJ');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (2,'CAIXA','CX');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (3,'JOGO','JG');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (4,'KIT','KT');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (5,'LITRO','LT');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (6,'PECA','PC');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (7,'MILIGRAMA','MG');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (8,'GRAMA','G');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (9,'KILOGRAMA','KG');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (10,'TONELADA','T');

insert  into `forma`(`Id`,`Nome`) values (1,'FORMA 1');
insert  into `forma`(`Id`,`Nome`) values (2,'FORMA 2');
insert  into `forma`(`Id`,`Nome`) values (3,'FORMA 3');
insert  into `forma`(`Id`,`Nome`) values (4,'FORMA 4');

insert  into `maquina`(`Id`,`Nome`) values (1,'MAQUINA 1');
insert  into `maquina`(`Id`,`Nome`) values (2,'MAQUINA 2');
insert  into `maquina`(`Id`,`Nome`) values (3,'MAQUINA 3');

insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (1,5,'JHIODAS89231','INGREDIENTE 1','11',150,'1');
insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (2,7,'UISD894','INGREDIENTE 2','55',30,'1');
insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (3,7,'UISD781','INGREDIENTE 3','1',500,'1');
insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (4,4,'WFJAIODA9','PRODUTO 1','120',5,'0');
insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (5,4,'WF9384F','PRODUTO 2','100',2,'0');

insert  into `tipo_massa`(`Id`,`FormaId`,`MaquinaId`,`NomeMassa`,`PesoBase`,`ValorBase`) values (1,1,1,'MASSA 1',10,'30');
insert  into `tipo_massa`(`Id`,`FormaId`,`MaquinaId`,`NomeMassa`,`PesoBase`,`ValorBase`) values (2,2,2,'MASSA 2',5,'10');
insert  into `tipo_massa`(`Id`,`FormaId`,`MaquinaId`,`NomeMassa`,`PesoBase`,`ValorBase`) values (3,2,3,'MASSA 3',20,'50');

insert into `tipo_massa_has_produto`(`TipoMassaId`,`ProdutoId`) values (1, 1);
insert into `tipo_massa_has_produto`(`TipoMassaId`,`ProdutoId`) values (1, 2);
insert into `tipo_massa_has_produto`(`TipoMassaId`,`ProdutoId`) values (1, 3);
insert into `tipo_massa_has_produto`(`TipoMassaId`,`ProdutoId`) values (2, 1);
insert into `tipo_massa_has_produto`(`TipoMassaId`,`ProdutoId`) values (2, 3);
insert into `tipo_massa_has_produto`(`TipoMassaId`,`ProdutoId`) values (3, 3);
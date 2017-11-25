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

INSERT INTO empresa (Bairro, Cep, Cnpj, InscEstadual, Logradouro, Numero, RazaoSocial) VALUES ('Santa Cecília', 94475808, '72247876000148', '9664394039', 'Beco do Aristides', '910', 'Mirella e João Telecom ME');
INSERT INTO empresa (Bairro, Cep, Cnpj, InscEstadual, Logradouro, Numero, RazaoSocial) VALUES ('Pedreira', 66080500, '54978694000165', '157705773', 'Vila São Judas Tadeu', '624', 'Caroline e Betina Entregas Expressas ME');
INSERT INTO empresa (Bairro, Cep, Cnpj, InscEstadual, Logradouro, Numero, RazaoSocial) VALUES ('Pernambués', 41100086, '46297426000150', '88400712', 'Rua Lamarão', '184', 'Nathan e Sophie Financeira Ltda');
INSERT INTO empresa (Bairro, Cep, Cnpj, InscEstadual, Logradouro, Numero, RazaoSocial) VALUES ('Parque Santa Madalena', 3983170, '72662159000182', '841969100265', 'Rua Ubim', '295', 'Kaique e Iago Assessoria Jurídica ME');
INSERT INTO empresa (Bairro, Cep, Cnpj, InscEstadual, Logradouro, Numero, RazaoSocial) VALUES ('Giardino D Itália', 13256222, '48125496000156', '421812062740', 'Rua Tito', '476', 'Juan e Caio Fotografias Ltda');
INSERT INTO empresa (Bairro, Cep, Cnpj, InscEstadual, Logradouro, Numero, RazaoSocial) VALUES ('Grajaú', 36052260, '19421097000134', '4780563276807', 'Travessa João Brun', '754', 'Natália e Mariana Entregas Expressas Ltda');
INSERT INTO empresa (Bairro, Cep, Cnpj, InscEstadual, Logradouro, Numero, RazaoSocial) VALUES ('Tiradentes', 79042549, '61321906000100', '280977140', 'Travessa Moana', '623', 'Diogo e Raul Alimentos Ltda');
INSERT INTO empresa (Bairro, Cep, Cnpj, InscEstadual, Logradouro, Numero, RazaoSocial) VALUES ('Jardim Batistão', 79094460, '46146882000107', '287872246', 'Rua Síria', '279', 'Felipe e Débora Padaria ME');
INSERT INTO empresa (Bairro, Cep, Cnpj, InscEstadual, Logradouro, Numero, RazaoSocial) VALUES ('Fradinhos', 29042650, '72495689000183', '419220968', 'Rua Professora Maria Acciolina Pereira', '738', 'Emily e Davi Mudanças ME');
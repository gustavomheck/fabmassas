insert  into unidade_medida(Id,Nome,Sigla) values (1,'Conjunto','CJ');
insert  into unidade_medida(Id,Nome,Sigla) values (2,'Caixa','CX');
insert  into unidade_medida(Id,Nome,Sigla) values (3,'Jogo','JG');
insert  into unidade_medida(Id,Nome,Sigla) values (4,'Kit','KT');
insert  into unidade_medida(Id,Nome,Sigla) values (5,'Litro','LT');
insert  into unidade_medida(Id,Nome,Sigla) values (6,'Peça','PC');
insert  into unidade_medida(Id,Nome,Sigla) values (7,'Miligrama','MG');
insert  into unidade_medida(Id,Nome,Sigla) values (8,'Grama','G');
insert  into unidade_medida(Id,Nome,Sigla) values (9,'Kilograma','KG');
insert  into unidade_medida(Id,Nome,Sigla) values (10,'Tonelada','T');

insert  into forma(Nome) values ('Espaguete');
insert  into forma(Nome) values ('Espaguete Fino');
insert  into forma(Nome) values ('Fettuccine');
insert  into forma(Nome) values ('Peni');
insert  into forma(Nome) values ('Talharim');

insert  into maquina(Nome) values ('Extrusora');
insert  into maquina(Nome) values ('Misturador');

insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (1,5,'JHIODAS89231','INGREDIENTE 1','11',150,'1');
insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (2,7,'UISD894','INGREDIENTE 2','55',30,'1');
insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (3,7,'UISD781','INGREDIENTE 3','1',500,'1');
insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (4,4,'WFJAIODA9','PRODUTO 1','120',5,'0');
insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (5,4,'WF9384F','PRODUTO 2','100',2,'0');

--insert  into `tipo_massa`(`Id`,`FormaId`,`MaquinaId`,`NomeMassa`,`PesoBase`,`ValorBase`) values (1,1,1,'MASSA 1',10,'30');
--insert  into `tipo_massa`(`Id`,`FormaId`,`MaquinaId`,`NomeMassa`,`PesoBase`,`ValorBase`) values (2,2,2,'MASSA 2',5,'10');
--insert  into `tipo_massa`(`Id`,`FormaId`,`MaquinaId`,`NomeMassa`,`PesoBase`,`ValorBase`) values (3,2,3,'MASSA 3',20,'50');

--insert into `tipo_massa_has_produto`(`TipoMassaId`,`ProdutoId`) values (1, 1);
--insert into `tipo_massa_has_produto`(`TipoMassaId`,`ProdutoId`) values (1, 2);
--insert into `tipo_massa_has_produto`(`TipoMassaId`,`ProdutoId`) values (1, 3);
--insert into `tipo_massa_has_produto`(`TipoMassaId`,`ProdutoId`) values (2, 1);
--insert into `tipo_massa_has_produto`(`TipoMassaId`,`ProdutoId`) values (2, 3);
--insert into `tipo_massa_has_produto`(`TipoMassaId`,`ProdutoId`) values (3, 3);

INSERT INTO empresa (Bairro, Cep, Cnpj, InscEstadual, Logradouro, Numero, RazaoSocial, Apelido, Site, Email) VALUES ('Centro', 96820042, '72247876000148', '9664394039', 'Rua Osvaldo Cruz', '175', 'Martin Massas Ltda', 'Martin Massas', 'www.martinmassas.com.br', 'contatomm@outlook.com');

INSERT INTO cliente (CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES ('31381708706', 'Mirella e João Telecom ME', '2801795750', '1280712616', 'www.mirellajao.com.br', 'mirellajao@gmail.com');
INSERT INTO cliente (CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES ('41285836000167', 'Caroline e Betina Entregas Expressas ME', '', '', 'www.nathanfinanceira.com.br', 'nathanfinanceira@outlook.com');
INSERT INTO cliente (CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES ('88636222648', 'Nathan e Sophie Financeira Ltda', '2477517290', '0900109831', '', '');
INSERT INTO cliente (CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES ('27714293000125', 'Kaique e Iago Assessoria Jurídica ME', '2934923066', '', 'www.kiassessoria.com', '');
INSERT INTO cliente (CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES ('38276521000149', 'Juan e Caio Fotografias Ltda', '6637311883', '', '', '');
INSERT INTO cliente (CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES ('63766651000107', 'Natália e Mariana Entregas Expressas Ltda', '2733090903', '', 'www.entregasexpr.net', 'entregasexpr@gmail.com');
INSERT INTO cliente (CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES ('32428282000119', 'Diogo e Raul Alimentos Ltda', '0775723231', '', '', '');
INSERT INTO cliente (CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES ('38866561000140', 'Felipe e Débora Padaria ME', '0565332643', '', 'www.lapadaria.com.br', 'lapadaria@gmail.com');
INSERT INTO cliente (CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES ('02440857000158', 'Diogo e Raul Alimentos Ltda', '5980488231', '', '', '');
INSERT INTO cliente (CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES ('93214941461', 'Emily e Davi Mudanças ME', '5599557436', '8770460610', '', 'davimudancas@hotmail.com');

INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (1, 37172949, 'Telefone fixo');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (2, 37170914, 'Telefone fixo');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (3, 37154829, '');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (4, 89980978, 'Celular');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (5, 37156759, 'Número de emergência');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (6, 37176683, '');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (7, 37194249, '');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (8, 98992847, 'Celular');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (9, 37176667, '');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (10, 37172949, 'Telefone fixo');


INSERT INTO unidade_medida (Id, Nome, Sigla) VALUES (1, 'Conjunto','CJ');
INSERT INTO unidade_medida (Id, Nome, Sigla) VALUES (2, 'Caixa','CX');
INSERT INTO unidade_medida (Id, Nome, Sigla) VALUES (3, 'Jogo','JG');
INSERT INTO unidade_medida (Id, Nome, Sigla) VALUES (4, 'Kit','KT');
INSERT INTO unidade_medida (Id, Nome, Sigla) VALUES (5, 'Litro','LT');
INSERT INTO unidade_medida (Id, Nome, Sigla) VALUES (6, 'Peça','PC');
INSERT INTO unidade_medida (Id, Nome, Sigla) VALUES (7, 'Miligrama','MG');
INSERT INTO unidade_medida (Id, Nome, Sigla) VALUES (8, 'Grama','G');
INSERT INTO unidade_medida (Id, Nome, Sigla) VALUES (9, 'Kilograma','KG');
INSERT INTO unidade_medida (Id, Nome, Sigla) VALUES (10, 'Tonelada','T');

INSERT INTO forma (Id, Nome) VALUES (1, 'Espaguete');
INSERT INTO forma (Id, Nome) VALUES (2, 'Espaguete Fino');
INSERT INTO forma (Id, Nome) VALUES (3, 'Fettuccine');
INSERT INTO forma (Id, Nome) VALUES (4, 'Peni');
INSERT INTO forma (Id, Nome) VALUES (5, 'Talharim');

INSERT INTO maquina (Id, Nome) VALUES (1, 'Extrusora');
INSERT INTO maquina (Id, Nome) VALUES (2, 'Misturador');

INSERT INTO `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) VALUES (1,5,'JHIODAS89231','INGREDIENTE 1','11',150,'1');
INSERT INTO `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) VALUES (2,7,'UISD894','INGREDIENTE 2','55',30,'1');
INSERT INTO `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) VALUES (3,7,'UISD781','INGREDIENTE 3','1',500,'1');
INSERT INTO `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) VALUES (4,4,'WFJAIODA9','PRODUTO 1','120',5,'0');
INSERT INTO `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) VALUES (5,4,'WF9384F','PRODUTO 2','100',2,'0');

INSERT INTO empresa (Id, Bairro, Cep, Cnpj, InscEstadual, Logradouro, Numero, RazaoSocial, Apelido, Site, Email) VALUES (1, 'Centro', 96820042, '72247876000148', '9664394039', 'Rua Osvaldo Cruz', '175', 'Martin Massas Ltda', 'Martin Massas', 'www.martinmassas.com.br', 'contatomm@outlook.com');

INSERT INTO cliente (Id, CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (1, '31381708706', 'Mirella e João Telecom ME', '2801795750', '12802616', 'www.mirellajao.com.br', 'mirellajao@gmail.com');
INSERT INTO cliente (Id, CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (2, '41285836000167', 'Caroline e Betina Entregas Expressas ME', '', '', 'www.nathanfinanceira.com.br', 'nathanfinanceira@outlook.com');
INSERT INTO cliente (Id, CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (3, '88636222648', 'Nathan e Sophie Financeira Ltda', '2477517290', '09009831', '', '');
INSERT INTO cliente (Id, CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (4, '27714293000125', 'Kaique e Iago Assessoria Jurídica ME', '2934923066', '', 'www.kiassessoria.com', '');
INSERT INTO cliente (Id, CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (5, '38276521000149', 'Juan e Caio Fotografias Ltda', '6637311883', '', '', '');
INSERT INTO cliente (Id, CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (6, '63766651000107', 'Natália e Mariana Entregas Expressas Ltda', '27390903', '', 'www.entregasexpr.net', 'entregasexpr@gmail.com');
INSERT INTO cliente (Id, CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (7, '32428282000119', 'Diogo e Raul Alimentos Ltda', '0775723231', '', '', '');
INSERT INTO cliente (Id, CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (8, '38866561000140', 'Felipe e Débora Padaria ME', '0565332643', '', 'www.lapadaria.com.br', 'lapadaria@gmail.com');
INSERT INTO cliente (Id, CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (9, '02440857000158', 'Diogo e Raul Alimentos Ltda', '5980488231', '', '', '');
INSERT INTO cliente (Id, CnpjCpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (10, '93214941461', 'Emily e Davi Mudanças ME', '5599557436', '87704610', '', 'davimudancas@hotmail.com');

INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (1, 37172949, 'Telefone fixo');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (2, 37170914, 'Telefone fixo');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (3, 37154829, '');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (4, 89980978, 'Celular');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (5, 37156759, 'Número de emergência');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (6, 37176683, '');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (7, 37194249, '');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (8, 98992847, 'Celular');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (9, 37176667, '');
INSERT INTO telefone (ClienteId, Numero, Observacao) VALUES (10, 37172949, 'Telefone fixo');
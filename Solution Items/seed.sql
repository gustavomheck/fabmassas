-- Unidade de Medida
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

-- Forma
INSERT INTO forma (Id, Nome) VALUES (1, 'Espaguete');
INSERT INTO forma (Id, Nome) VALUES (2, 'Espaguete Fino');
INSERT INTO forma (Id, Nome) VALUES (3, 'Fettuccine');
INSERT INTO forma (Id, Nome) VALUES (4, 'Peni');
INSERT INTO forma (Id, Nome) VALUES (5, 'Talharim');

-- Máquina
INSERT INTO maquina (Id, Nome) VALUES (1, 'Extrusora');
INSERT INTO maquina (Id, Nome) VALUES (2, 'Misturador');

-- Empresa
INSERT INTO empresa (Id, Bairro, Cep, Cnpj, InscEstadual, Logradouro, Numero, RazaoSocial, Apelido, Site, Email) VALUES (1, 'Centro', 96820042, '72247876000148', '9664394039', 'Rua Osvaldo Cruz', '175', 'Martin Massas Ltda', 'Martin Massas', 'www.martinmassas.com.br', 'contatomm@outlook.com');

-- Cliente
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

-- Telefone
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

-- Produto
INSERT INTO produto (Id, UnidadeMedidaId, Codigo, Nome, ValorBase, QtdeMinimaEstoque, IsIngrediente) VALUES(1, 5, 'JHIODAS89231', 'SACOLA PLÁSTICA', '0', '100', '0');
INSERT INTO produto (Id, UnidadeMedidaId, Codigo, Nome, ValorBase, QtdeMinimaEstoque, IsIngrediente) VALUES(2, 7, 'UISD894','OVO', '1', '500', '1');
INSERT INTO produto (Id, UnidadeMedidaId, Codigo, Nome, ValorBase, QtdeMinimaEstoque, IsIngrediente) VALUES(3, 7, 'UISD781','FARINHA', '27', '200', '1');
INSERT INTO produto (Id, UnidadeMedidaId, Codigo, Nome, ValorBase, QtdeMinimaEstoque, IsIngrediente) VALUES(4, 4, 'WFJAIODA9','CORANTE AMARELO', '20', '1', '1');
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
INSERT INTO cliente (Id, Cnpj, Cpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (1, '', '31381708706', 'Mirella e João Telecom ME', '2801795750', '12802616', 'www.mirellajao.com.br', 'mirellajao@gmail.com');
INSERT INTO cliente (Id, Cnpj, Cpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (2, '41285836000167', '', 'Caroline e Betina Entregas Expressas ME', '', '', 'www.nathanfinanceira.com.br', 'nathanfinanceira@outlook.com');
INSERT INTO cliente (Id, Cnpj, Cpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (3, '', '88636222648', 'Nathan e Sophie Financeira Ltda', '2477517290', '09009831', '', '');
INSERT INTO cliente (Id, Cnpj, Cpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (4, '27714293000125', '', 'Kaique e Iago Assessoria Jurídica ME', '2934923066', '', 'www.kiassessoria.com', '');
INSERT INTO cliente (Id, Cnpj, Cpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (5, '38276521000149', '', 'Juan e Caio Fotografias Ltda', '6637311883', '', '', '');
INSERT INTO cliente (Id, Cnpj, Cpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (6, '63766651000107', '', 'Natália e Mariana Entregas Expressas Ltda', '27390903', '', 'www.entregasexpr.com', 'entregasexpr@gmail.com');
INSERT INTO cliente (Id, Cnpj, Cpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (7, '32428282000119', '', 'Diogo e Raul Alimentos Ltda', '0775723231', '', '', '');
INSERT INTO cliente (Id, Cnpj, Cpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (8, '38866561000140', '', 'Felipe e Débora Padaria ME', '0565332643', '', 'www.lapadaria.com.br', 'lapadaria@gmail.com');
INSERT INTO cliente (Id, Cnpj, Cpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (9, '02440857000158', '', 'Diogo e Raul Alimentos Ltda', '5980488231', '', '', '');
INSERT INTO cliente (Id, Cnpj, Cpf, Nome, InscEstadual, InscMunicipal, Site, Email) VALUES (10, '', '93214941461', 'Emily e Davi Mudanças ME', '5599557436', '87704610', '', 'davimudancas@hotmail.com');

-- Local
INSERT INTO `local` (`Id`, `ClienteId`, `Cep`, `Cidade`, `Logradouro`, `Bairro`, `Numero`, `Complemento`) VALUES('1','1','96815640','Santa Cruz do Sul','Rua Dona Flora','Universitário','452','Esquina');
INSERT INTO `local` (`Id`, `ClienteId`, `Cep`, `Cidade`, `Logradouro`, `Bairro`, `Numero`, `Complemento`) VALUES('2','2','96815710','Santa Cruz do Sul','Rua Vinte e Oito de Outubro','Universitário','1467',NULL);
INSERT INTO `local` (`Id`, `ClienteId`, `Cep`, `Cidade`, `Logradouro`, `Bairro`, `Numero`, `Complemento`) VALUES('3','3','96820510','Santa Cruz do Sul','Rua Conselheiro Trockel','Santo Inácio','332',NULL);
INSERT INTO `local` (`Id`, `ClienteId`, `Cep`, `Cidade`, `Logradouro`, `Bairro`, `Numero`, `Complemento`) VALUES('4','4','96815680','Santa Cruz do Sul','Rua Padre Amstad','Universitário','490','Alvenaria');
INSERT INTO `local` (`Id`, `ClienteId`, `Cep`, `Cidade`, `Logradouro`, `Bairro`, `Numero`, `Complemento`) VALUES('5','5','96815360','Santa Cruz do Sul','Corredor Soder','Independência','711','Esquina');
INSERT INTO `local` (`Id`, `ClienteId`, `Cep`, `Cidade`, `Logradouro`, `Bairro`, `Numero`, `Complemento`) VALUES('6','7','96820080','Santa Cruz do Sul','Rua Professor Cristiano João Smidt','Santo Inácio','389',NULL);
INSERT INTO `local` (`Id`, `ClienteId`, `Cep`, `Cidade`, `Logradouro`, `Bairro`, `Numero`, `Complemento`) VALUES('7','8','96820050','Santa Cruz do Sul','Avenida Senador Pasqualini','Santo Inácio','185',NULL);
INSERT INTO `local` (`Id`, `ClienteId`, `Cep`, `Cidade`, `Logradouro`, `Bairro`, `Numero`, `Complemento`) VALUES('8','9','96815360','Santa Cruz do Sul','Corredor Soder','Independência','234','Esquina');
INSERT INTO `local` (`Id`, `ClienteId`, `Cep`, `Cidade`, `Logradouro`, `Bairro`, `Numero`, `Complemento`) VALUES('9','10','96815720','Santa Cruz do Sul','Rua Andrade Neves','Universitário','1048',NULL);

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

-- Tipo Massa
INSERT INTO tipo_massa (Id, FormaId, MaquinaId, NomeMassa, PesoBase, ValorBase) VALUES (1, 1, 1, 'Espaguete', 500, 4.75);
INSERT INTO tipo_massa (Id, FormaId, MaquinaId, NomeMassa, PesoBase, ValorBase) VALUES (2, 2, 1, 'Espaguete Fino', 500, 5.75);
INSERT INTO tipo_massa (Id, FormaId, MaquinaId, NomeMassa, PesoBase, ValorBase) VALUES (3, 3, 1, 'Fettuccine', 800, 8.75);
INSERT INTO tipo_massa (Id, FormaId, MaquinaId, NomeMassa, PesoBase, ValorBase) VALUES (4, 4, 2, 'Peni', 300, 3);
INSERT INTO tipo_massa (Id, FormaId, MaquinaId, NomeMassa, PesoBase, ValorBase) VALUES (5, 5, 1, 'Talharim', 500, 4.75);

-- Estoque
INSERT INTO estoque (Id, ProdutoId, DataEntrada, DataVencimento, ValorProduto, ValorUnidade, QuantComprada, QuantDisponivel) VALUES(1, 1,'2017-10-04 13:35:25', NULL, 10, 0.1, 100, 100);
INSERT INTO estoque (Id, ProdutoId, DataEntrada, DataVencimento, ValorProduto, ValorUnidade, QuantComprada, QuantDisponivel) VALUES(2, 2,'2017-12-03 13:35:25', '2018-01-04 13:35:25', 138, 6.9, 200, 200);
INSERT INTO estoque (Id, ProdutoId, DataEntrada, DataVencimento, ValorProduto, ValorUnidade, QuantComprada, QuantDisponivel) VALUES(3, 3,'2017-12-04 13:35:25', NULL, 204.8, 12.80, 16, 16);
INSERT INTO estoque (Id, ProdutoId, DataEntrada, DataVencimento, ValorProduto, ValorUnidade, QuantComprada, QuantDisponivel) VALUES(4, 4,'2017-12-01 13:35:25', '2020-12-01 13:35:25', 3, 3, 1, 0);

-- Encomenda
INSERT INTO `encomenda` (`Id`, `ClienteId`, `EmpresaId`, `LocalId`, `DataPedido`, `DataEntrega`, `Peso`, `Valor`, `QuantPacotes`, `Status`) VALUES(1,'1','1','1','2017-12-08 11:00:00','2017-12-14 09:30:00','20000','200','40','0');
INSERT INTO `encomenda` (`Id`, `ClienteId`, `EmpresaId`, `LocalId`, `DataPedido`, `DataEntrega`, `Peso`, `Valor`, `QuantPacotes`, `Status`) VALUES(2,'2','1','2','2017-12-08 02:10:00','2017-12-10 12:00:00','42500','480','55','1');

-- Pacote
INSERT INTO `pacotes` (`Id`, `EncomendaId`, `TipoMassaId`, `Quantidade`) VALUES(1, 1, 1, 40);
INSERT INTO `pacotes` (`Id`, `EncomendaId`, `TipoMassaId`, `Quantidade`) VALUES(2, 2, 2, 5);
INSERT INTO `pacotes` (`Id`, `EncomendaId`, `TipoMassaId`, `Quantidade`) VALUES(3, 2, 3, 50);
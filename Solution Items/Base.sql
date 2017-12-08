/*
SQLyog Ultimate v11.5 (64 bit)
MySQL - 5.6.21-log : Database - massas
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
/*Table structure for table `cliente` */

DROP TABLE IF EXISTS `cliente`;

CREATE TABLE `cliente` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Cnpj` varchar(14) DEFAULT NULL,
  `Cpf` varchar(11) DEFAULT NULL,
  `Nome` varchar(60) NOT NULL,
  `InscEstadual` varchar(12) DEFAULT NULL,
  `InscMunicipal` varchar(9) DEFAULT NULL,
  `Site` varchar(255) DEFAULT NULL,
  `Email` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

/*Data for the table `cliente` */

insert  into `cliente`(`Id`,`Cnpj`,`Cpf`,`Nome`,`InscEstadual`,`InscMunicipal`,`Site`,`Email`) values (1,'','31381708706','Mirella e João Telecom ME','2801795750','12802616','www.mirellajao.com.br','mirellajao@gmail.com');
insert  into `cliente`(`Id`,`Cnpj`,`Cpf`,`Nome`,`InscEstadual`,`InscMunicipal`,`Site`,`Email`) values (2,'41285836000167','','Caroline e Betina Entregas Expressas ME','','','www.nathanfinanceira.com.br','nathanfinanceira@outlook.com');
insert  into `cliente`(`Id`,`Cnpj`,`Cpf`,`Nome`,`InscEstadual`,`InscMunicipal`,`Site`,`Email`) values (3,'','88636222648','Nathan e Sophie Financeira Ltda','2477517290','09009831','','');
insert  into `cliente`(`Id`,`Cnpj`,`Cpf`,`Nome`,`InscEstadual`,`InscMunicipal`,`Site`,`Email`) values (4,'27714293000125','','Kaique e Iago Assessoria Jurídica ME','2934923066','','www.kiassessoria.com','');
insert  into `cliente`(`Id`,`Cnpj`,`Cpf`,`Nome`,`InscEstadual`,`InscMunicipal`,`Site`,`Email`) values (5,'38276521000149','','Juan e Caio Fotografias Ltda','6637311883','','','');
insert  into `cliente`(`Id`,`Cnpj`,`Cpf`,`Nome`,`InscEstadual`,`InscMunicipal`,`Site`,`Email`) values (6,'63766651000107','','Natália e Mariana Entregas Expressas Ltda','27390903','','www.entregasexpr.com','entregasexpr@gmail.com');
insert  into `cliente`(`Id`,`Cnpj`,`Cpf`,`Nome`,`InscEstadual`,`InscMunicipal`,`Site`,`Email`) values (7,'32428282000119','','Diogo e Raul Alimentos Ltda','0775723231','','','');
insert  into `cliente`(`Id`,`Cnpj`,`Cpf`,`Nome`,`InscEstadual`,`InscMunicipal`,`Site`,`Email`) values (8,'38866561000140','','Felipe e Débora Padaria ME','0565332643','','www.lapadaria.com.br','lapadaria@gmail.com');
insert  into `cliente`(`Id`,`Cnpj`,`Cpf`,`Nome`,`InscEstadual`,`InscMunicipal`,`Site`,`Email`) values (9,'02440857000158','','Diogo e Raul Alimentos Ltda','5980488231','','','');
insert  into `cliente`(`Id`,`Cnpj`,`Cpf`,`Nome`,`InscEstadual`,`InscMunicipal`,`Site`,`Email`) values (10,'','93214941461','Emily e Davi Mudanças ME','5599557436','87704610','','davimudancas@hotmail.com');

/*Table structure for table `empresa` */

DROP TABLE IF EXISTS `empresa`;

CREATE TABLE `empresa` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Cnpj` varchar(14) NOT NULL,
  `InscEstadual` varchar(15) DEFAULT NULL,
  `InscMunicipal` varchar(12) DEFAULT NULL,
  `RazaoSocial` varchar(60) NOT NULL,
  `Apelido` varchar(60) DEFAULT NULL,
  `Logomarca` varchar(255) DEFAULT NULL,
  `Cep` int(8) NOT NULL,
  `Bairro` varchar(60) NOT NULL,
  `Logradouro` varchar(60) NOT NULL,
  `Numero` varchar(20) NOT NULL,
  `Site` varchar(255) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `empresa` */

insert  into `empresa`(`Id`,`Cnpj`,`InscEstadual`,`InscMunicipal`,`RazaoSocial`,`Apelido`,`Logomarca`,`Cep`,`Bairro`,`Logradouro`,`Numero`,`Site`,`Email`) values (1,'72247876000148','9664394039',NULL,'Martin Massas Ltda','Martin Massas',NULL,96820042,'Centro','Rua Osvaldo Cruz','175','www.martinmassas.com.br','contatomm@outlook.com');

/*Table structure for table `encomenda` */

DROP TABLE IF EXISTS `encomenda`;

CREATE TABLE `encomenda` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClienteId` int(11) NOT NULL,
  `EmpresaId` int(11) NOT NULL,
  `LocalId` int(11) NOT NULL,
  `DataPedido` datetime NOT NULL,
  `DataEntrega` datetime DEFAULT NULL,
  `Peso` double NOT NULL,
  `Valor` decimal(10,0) NOT NULL,
  `QuantPacotes` int(11) NOT NULL,
  `Status` int(2) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_encomenda_cliente1_idx` (`ClienteId`),
  KEY `fk_encomenda_empresa1_idx` (`EmpresaId`),
  KEY `fk_encomenda_local1` (`LocalId`),
  CONSTRAINT `fk_encomenda_cliente1` FOREIGN KEY (`ClienteId`) REFERENCES `cliente` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_encomenda_empresa1` FOREIGN KEY (`EmpresaId`) REFERENCES `empresa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_encomenda_local1` FOREIGN KEY (`LocalId`) REFERENCES `local` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

/*Data for the table `encomenda` */

insert  into `encomenda`(`Id`,`ClienteId`,`EmpresaId`,`LocalId`,`DataPedido`,`DataEntrega`,`Peso`,`Valor`,`QuantPacotes`,`Status`) values (1,1,1,1,'2017-12-08 11:00:00','2017-12-14 09:30:00',20000,'200',40,0);
insert  into `encomenda`(`Id`,`ClienteId`,`EmpresaId`,`LocalId`,`DataPedido`,`DataEntrega`,`Peso`,`Valor`,`QuantPacotes`,`Status`) values (2,2,1,2,'2017-12-08 02:10:00','2017-12-10 12:00:00',42500,'480',55,1);

/*Table structure for table `estoque` */

DROP TABLE IF EXISTS `estoque`;

CREATE TABLE `estoque` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProdutoId` int(11) NOT NULL,
  `DataEntrada` datetime NOT NULL,
  `DataVencimento` datetime DEFAULT NULL,
  `ValorProduto` decimal(10,0) NOT NULL,
  `ValorUnidade` decimal(10,0) NOT NULL,
  `QuantComprada` double NOT NULL,
  `QuantDisponivel` double NOT NULL,
  PRIMARY KEY (`Id`,`ProdutoId`),
  KEY `fk_estoque_produto1_idx` (`ProdutoId`),
  CONSTRAINT `fk_estoque_produto1` FOREIGN KEY (`ProdutoId`) REFERENCES `produto` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

/*Data for the table `estoque` */

insert  into `estoque`(`Id`,`ProdutoId`,`DataEntrada`,`DataVencimento`,`ValorProduto`,`ValorUnidade`,`QuantComprada`,`QuantDisponivel`) values (1,1,'2017-10-04 13:35:25',NULL,'10','0',100,100);
insert  into `estoque`(`Id`,`ProdutoId`,`DataEntrada`,`DataVencimento`,`ValorProduto`,`ValorUnidade`,`QuantComprada`,`QuantDisponivel`) values (2,2,'2017-12-03 13:35:25','2018-01-04 13:35:25','138','7',200,200);
insert  into `estoque`(`Id`,`ProdutoId`,`DataEntrada`,`DataVencimento`,`ValorProduto`,`ValorUnidade`,`QuantComprada`,`QuantDisponivel`) values (3,3,'2017-12-04 13:35:25',NULL,'205','13',16,16);
insert  into `estoque`(`Id`,`ProdutoId`,`DataEntrada`,`DataVencimento`,`ValorProduto`,`ValorUnidade`,`QuantComprada`,`QuantDisponivel`) values (4,4,'2017-12-01 13:35:25','2020-12-01 13:35:25','3','3',1,0);

/*Table structure for table `forma` */

DROP TABLE IF EXISTS `forma`;

CREATE TABLE `forma` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

/*Data for the table `forma` */

insert  into `forma`(`Id`,`Nome`) values (1,'Espaguete');
insert  into `forma`(`Id`,`Nome`) values (2,'Espaguete Fino');
insert  into `forma`(`Id`,`Nome`) values (3,'Fettuccine');
insert  into `forma`(`Id`,`Nome`) values (4,'Peni');
insert  into `forma`(`Id`,`Nome`) values (5,'Talharim');

/*Table structure for table `funcao` */

DROP TABLE IF EXISTS `funcao`;

CREATE TABLE `funcao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `funcao` */

/*Table structure for table `funcao_usuario` */

DROP TABLE IF EXISTS `funcao_usuario`;

CREATE TABLE `funcao_usuario` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UsuarioId` int(11) NOT NULL,
  `FuncaoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`,`UsuarioId`,`FuncaoId`),
  KEY `fk_funcao_usuario_usuario1_idx` (`UsuarioId`),
  KEY `fk_funcao_usuario_funcao1_idx` (`FuncaoId`),
  CONSTRAINT `fk_funcao_usuario_funcao1` FOREIGN KEY (`FuncaoId`) REFERENCES `funcao` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_funcao_usuario_usuario1` FOREIGN KEY (`UsuarioId`) REFERENCES `usuario` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `funcao_usuario` */

/*Table structure for table `local` */

DROP TABLE IF EXISTS `local`;

CREATE TABLE `local` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClienteId` int(11) NOT NULL,
  `Cep` int(8) NOT NULL,
  `Cidade` varchar(45) DEFAULT NULL,
  `Logradouro` varchar(60) NOT NULL,
  `Bairro` varchar(45) NOT NULL,
  `Numero` varchar(20) DEFAULT NULL,
  `Complemento` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_local_cliente1_idx` (`ClienteId`),
  CONSTRAINT `fk_local_cliente1` FOREIGN KEY (`ClienteId`) REFERENCES `cliente` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

/*Data for the table `local` */

insert  into `local`(`Id`,`ClienteId`,`Cep`,`Cidade`,`Logradouro`,`Bairro`,`Numero`,`Complemento`) values (1,1,96815640,'Santa Cruz do Sul','Rua Dona Flora','Universitário','452','Esquina');
insert  into `local`(`Id`,`ClienteId`,`Cep`,`Cidade`,`Logradouro`,`Bairro`,`Numero`,`Complemento`) values (2,2,96815710,'Santa Cruz do Sul','Rua Vinte e Oito de Outubro','Universitário','1467',NULL);
insert  into `local`(`Id`,`ClienteId`,`Cep`,`Cidade`,`Logradouro`,`Bairro`,`Numero`,`Complemento`) values (3,3,96820510,'Santa Cruz do Sul','Rua Conselheiro Trockel','Santo Inácio','332',NULL);
insert  into `local`(`Id`,`ClienteId`,`Cep`,`Cidade`,`Logradouro`,`Bairro`,`Numero`,`Complemento`) values (4,4,96815680,'Santa Cruz do Sul','Rua Padre Amstad','Universitário','490','Alvenaria');
insert  into `local`(`Id`,`ClienteId`,`Cep`,`Cidade`,`Logradouro`,`Bairro`,`Numero`,`Complemento`) values (5,5,96815360,'Santa Cruz do Sul','Corredor Soder','Independência','711','Esquina');
insert  into `local`(`Id`,`ClienteId`,`Cep`,`Cidade`,`Logradouro`,`Bairro`,`Numero`,`Complemento`) values (6,7,96820080,'Santa Cruz do Sul','Rua Professor Cristiano João Smidt','Santo Inácio','389',NULL);
insert  into `local`(`Id`,`ClienteId`,`Cep`,`Cidade`,`Logradouro`,`Bairro`,`Numero`,`Complemento`) values (7,8,96820050,'Santa Cruz do Sul','Avenida Senador Pasqualini','Santo Inácio','185',NULL);
insert  into `local`(`Id`,`ClienteId`,`Cep`,`Cidade`,`Logradouro`,`Bairro`,`Numero`,`Complemento`) values (8,9,96815360,'Santa Cruz do Sul','Corredor Soder','Independência','234','Esquina');
insert  into `local`(`Id`,`ClienteId`,`Cep`,`Cidade`,`Logradouro`,`Bairro`,`Numero`,`Complemento`) values (9,10,96815720,'Santa Cruz do Sul','Rua Andrade Neves','Universitário','1048',NULL);

/*Table structure for table `maquina` */

DROP TABLE IF EXISTS `maquina`;

CREATE TABLE `maquina` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

/*Data for the table `maquina` */

insert  into `maquina`(`Id`,`Nome`) values (1,'Extrusora');
insert  into `maquina`(`Id`,`Nome`) values (2,'Misturador');

/*Table structure for table `pacotes` */

DROP TABLE IF EXISTS `pacotes`;

CREATE TABLE `pacotes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `EncomendaId` int(11) NOT NULL,
  `TipoMassaId` int(11) NOT NULL,
  `Quantidade` int(11) NOT NULL,
  PRIMARY KEY (`Id`,`EncomendaId`,`TipoMassaId`),
  KEY `fk_encomenda_has_tipo_massa_tipo_massa1_idx` (`TipoMassaId`),
  KEY `fk_encomenda_has_tipo_massa_encomenda1_idx` (`EncomendaId`),
  CONSTRAINT `fk_encomenda_has_tipo_massa_encomenda1` FOREIGN KEY (`EncomendaId`) REFERENCES `encomenda` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_encomenda_has_tipo_massa_tipo_massa1` FOREIGN KEY (`TipoMassaId`) REFERENCES `tipo_massa` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `pacotes` */

insert  into `pacotes`(`Id`,`EncomendaId`,`TipoMassaId`,`Quantidade`) values (1,1,1,40);
insert  into `pacotes`(`Id`,`EncomendaId`,`TipoMassaId`,`Quantidade`) values (2,2,2,5);
insert  into `pacotes`(`Id`,`EncomendaId`,`TipoMassaId`,`Quantidade`) values (3,2,3,50);

/*Table structure for table `permissao` */

DROP TABLE IF EXISTS `permissao`;

CREATE TABLE `permissao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TituloPermissao` varchar(60) NOT NULL,
  `NomePermissao` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `permissao` */

/*Table structure for table `permissao_funcao` */

DROP TABLE IF EXISTS `permissao_funcao`;

CREATE TABLE `permissao_funcao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FuncaoId` int(11) NOT NULL,
  `PermissaoId` int(11) NOT NULL,
  PRIMARY KEY (`Id`,`FuncaoId`,`PermissaoId`),
  KEY `fk_permissao_funcao_funcao1_idx` (`FuncaoId`),
  KEY `fk_permissao_funcao_permissao1_idx` (`PermissaoId`),
  CONSTRAINT `fk_permissao_funcao_funcao1` FOREIGN KEY (`FuncaoId`) REFERENCES `funcao` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_permissao_funcao_permissao1` FOREIGN KEY (`PermissaoId`) REFERENCES `permissao` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `permissao_funcao` */

/*Table structure for table `produto` */

DROP TABLE IF EXISTS `produto`;

CREATE TABLE `produto` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UnidadeMedidaId` int(11) NOT NULL,
  `Codigo` varchar(60) NOT NULL,
  `Nome` varchar(45) NOT NULL,
  `ValorBase` decimal(10,0) NOT NULL,
  `QtdeMinimaEstoque` double NOT NULL,
  `IsIngrediente` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_produto_unidade_medida1_idx` (`UnidadeMedidaId`),
  CONSTRAINT `fk_produto_unidade_medida1` FOREIGN KEY (`UnidadeMedidaId`) REFERENCES `unidade_medida` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `produto` */

insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (1,5,'JHIODAS89231','SACOLA PLÁSTICA','0',100,0);
insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (2,7,'UISD894','OVO','1',500,1);
insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (3,7,'UISD781','FARINHA','27',200,1);
insert  into `produto`(`Id`,`UnidadeMedidaId`,`Codigo`,`Nome`,`ValorBase`,`QtdeMinimaEstoque`,`IsIngrediente`) values (4,4,'WFJAIODA9','CORANTE AMARELO','20',1,1);

/*Table structure for table `telefone` */

DROP TABLE IF EXISTS `telefone`;

CREATE TABLE `telefone` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `EmpresaId` int(11) DEFAULT NULL,
  `ClienteId` int(11) DEFAULT NULL,
  `Numero` int(11) NOT NULL,
  `Observacao` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_telefone_empresa1_idx` (`EmpresaId`),
  KEY `fk_telefone_cliente1_idx` (`ClienteId`),
  CONSTRAINT `fk_telefone_cliente1` FOREIGN KEY (`ClienteId`) REFERENCES `cliente` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_telefone_empresa1` FOREIGN KEY (`EmpresaId`) REFERENCES `empresa` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1291 DEFAULT CHARSET=utf8;

/*Data for the table `telefone` */

insert  into `telefone`(`Id`,`EmpresaId`,`ClienteId`,`Numero`,`Observacao`) values (1281,NULL,1,37172949,'Telefone fixo');
insert  into `telefone`(`Id`,`EmpresaId`,`ClienteId`,`Numero`,`Observacao`) values (1282,NULL,2,37170914,'Telefone fixo');
insert  into `telefone`(`Id`,`EmpresaId`,`ClienteId`,`Numero`,`Observacao`) values (1283,NULL,3,37154829,'');
insert  into `telefone`(`Id`,`EmpresaId`,`ClienteId`,`Numero`,`Observacao`) values (1284,NULL,4,89980978,'Celular');
insert  into `telefone`(`Id`,`EmpresaId`,`ClienteId`,`Numero`,`Observacao`) values (1285,NULL,5,37156759,'Número de emergência');
insert  into `telefone`(`Id`,`EmpresaId`,`ClienteId`,`Numero`,`Observacao`) values (1286,NULL,6,37176683,'');
insert  into `telefone`(`Id`,`EmpresaId`,`ClienteId`,`Numero`,`Observacao`) values (1287,NULL,7,37194249,'');
insert  into `telefone`(`Id`,`EmpresaId`,`ClienteId`,`Numero`,`Observacao`) values (1288,NULL,8,98992847,'Celular');
insert  into `telefone`(`Id`,`EmpresaId`,`ClienteId`,`Numero`,`Observacao`) values (1289,NULL,9,37176667,'');
insert  into `telefone`(`Id`,`EmpresaId`,`ClienteId`,`Numero`,`Observacao`) values (1290,NULL,10,37172949,'Telefone fixo');

/*Table structure for table `tipo_massa` */

DROP TABLE IF EXISTS `tipo_massa`;

CREATE TABLE `tipo_massa` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FormaId` int(11) NOT NULL,
  `MaquinaId` int(11) NOT NULL,
  `NomeMassa` varchar(45) NOT NULL,
  `PesoBase` double NOT NULL,
  `ValorBase` decimal(10,0) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_tipo_massa_forma1` (`FormaId`),
  KEY `fk_tipo_massa_maquina1` (`MaquinaId`),
  CONSTRAINT `fk_tipo_massa_forma1` FOREIGN KEY (`FormaId`) REFERENCES `forma` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tipo_massa_maquina1` FOREIGN KEY (`MaquinaId`) REFERENCES `maquina` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

/*Data for the table `tipo_massa` */

insert  into `tipo_massa`(`Id`,`FormaId`,`MaquinaId`,`NomeMassa`,`PesoBase`,`ValorBase`) values (1,1,1,'Espaguete',500,'5');
insert  into `tipo_massa`(`Id`,`FormaId`,`MaquinaId`,`NomeMassa`,`PesoBase`,`ValorBase`) values (2,2,1,'Espaguete Fino',500,'6');
insert  into `tipo_massa`(`Id`,`FormaId`,`MaquinaId`,`NomeMassa`,`PesoBase`,`ValorBase`) values (3,3,1,'Fettuccine',800,'9');
insert  into `tipo_massa`(`Id`,`FormaId`,`MaquinaId`,`NomeMassa`,`PesoBase`,`ValorBase`) values (4,4,2,'Peni',300,'3');
insert  into `tipo_massa`(`Id`,`FormaId`,`MaquinaId`,`NomeMassa`,`PesoBase`,`ValorBase`) values (5,5,1,'Talharim',500,'5');

/*Table structure for table `tipo_massa_has_produto` */

DROP TABLE IF EXISTS `tipo_massa_has_produto`;

CREATE TABLE `tipo_massa_has_produto` (
  `TipoMassaId` int(11) NOT NULL,
  `ProdutoId` int(11) NOT NULL,
  PRIMARY KEY (`TipoMassaId`,`ProdutoId`),
  KEY `fk_tipo_massa_has_ingrediente_ingrediente1_idx` (`ProdutoId`),
  KEY `fk_tipo_massa_has_ingrediente_tipo_massa1_idx` (`TipoMassaId`),
  CONSTRAINT `fk_tipo_massa_has_ingrediente_ingrediente1` FOREIGN KEY (`ProdutoId`) REFERENCES `produto` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_tipo_massa_has_ingrediente_tipo_massa1` FOREIGN KEY (`TipoMassaId`) REFERENCES `tipo_massa` (`Id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tipo_massa_has_produto` */

/*Table structure for table `unidade_medida` */

DROP TABLE IF EXISTS `unidade_medida`;

CREATE TABLE `unidade_medida` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(20) NOT NULL,
  `Sigla` varchar(6) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

/*Data for the table `unidade_medida` */

insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (1,'Conjunto','CJ');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (2,'Caixa','CX');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (3,'Jogo','JG');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (4,'Kit','KT');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (5,'Litro','LT');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (6,'Peça','PC');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (7,'Miligrama','MG');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (8,'Grama','G');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (9,'Kilograma','KG');
insert  into `unidade_medida`(`Id`,`Nome`,`Sigla`) values (10,'Tonelada','T');

/*Table structure for table `usuario` */

DROP TABLE IF EXISTS `usuario`;

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `LoginUsuario` varchar(60) NOT NULL,
  `Senha` varchar(32) NOT NULL,
  `Nome` varchar(60) NOT NULL,
  `Email` varchar(60) DEFAULT NULL,
  `IsSuperAdmin` tinyint(1) NOT NULL,
  `DataCriacao` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `usuario` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

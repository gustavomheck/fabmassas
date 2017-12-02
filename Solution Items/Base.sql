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
/*Table structure for table `cidade` */

DROP TABLE IF EXISTS `cidade`;

CREATE TABLE `cidade` (
  `Id` int(11) NOT NULL,
  `EstadoId` int(11) NOT NULL,
  `Nome` varchar(45) NOT NULL,
  `CodIbge` int(7) NOT NULL,
  `DensidadeDemo` decimal(10,2) DEFAULT NULL,
  `Populacao` varchar(45) DEFAULT NULL,
  `Gentilico` varchar(250) DEFAULT NULL,
  `Area` decimal(10,3) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_cidade_estado1_idx` (`EstadoId`),
  CONSTRAINT `fk_cidade_estado1` FOREIGN KEY (`EstadoId`) REFERENCES `estado` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `cidade` */

/*Table structure for table `cliente` */

DROP TABLE IF EXISTS `cliente`;

CREATE TABLE `cliente` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CnpjCpf` varchar(14) NOT NULL,
  `Nome` varchar(60) NOT NULL,
  `InscEstadual` varchar(12) DEFAULT NULL,
  `InscMunicipal` varchar(9) DEFAULT NULL,
  `Site` varchar(255) DEFAULT NULL,
  `Email` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `cliente` */

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
) ENGINE=InnoDB AUTO_INCREMENT=699 DEFAULT CHARSET=utf8;

/*Data for the table `empresa` */

insert  into `empresa`(`Id`,`Cnpj`,`InscEstadual`,`InscMunicipal`,`RazaoSocial`,`Apelido`,`Logomarca`,`Cep`,`Bairro`,`Logradouro`,`Numero`,`Site`,`Email`) values (690,'72247876000148','9664394039',NULL,'Mirella e João Telecom ME',NULL,NULL,94475808,'Santa Cecília','Beco do Aristides','910',NULL,NULL);
insert  into `empresa`(`Id`,`Cnpj`,`InscEstadual`,`InscMunicipal`,`RazaoSocial`,`Apelido`,`Logomarca`,`Cep`,`Bairro`,`Logradouro`,`Numero`,`Site`,`Email`) values (691,'54978694000165','157705773',NULL,'Caroline e Betina Entregas Expressas ME',NULL,NULL,66080500,'Pedreira','Vila São Judas Tadeu','624',NULL,NULL);
insert  into `empresa`(`Id`,`Cnpj`,`InscEstadual`,`InscMunicipal`,`RazaoSocial`,`Apelido`,`Logomarca`,`Cep`,`Bairro`,`Logradouro`,`Numero`,`Site`,`Email`) values (692,'46297426000150','88400712',NULL,'Nathan e Sophie Financeira Ltda',NULL,NULL,41100086,'Pernambués','Rua Lamarão','184',NULL,NULL);
insert  into `empresa`(`Id`,`Cnpj`,`InscEstadual`,`InscMunicipal`,`RazaoSocial`,`Apelido`,`Logomarca`,`Cep`,`Bairro`,`Logradouro`,`Numero`,`Site`,`Email`) values (693,'72662159000182','841969100265',NULL,'Kaique e Iago Assessoria Jurídica ME',NULL,NULL,3983170,'Parque Santa Madalena','Rua Ubim','295',NULL,NULL);
insert  into `empresa`(`Id`,`Cnpj`,`InscEstadual`,`InscMunicipal`,`RazaoSocial`,`Apelido`,`Logomarca`,`Cep`,`Bairro`,`Logradouro`,`Numero`,`Site`,`Email`) values (694,'48125496000156','421812062740',NULL,'Juan e Caio Fotografias Ltda',NULL,NULL,13256222,'Giardino D Itália','Rua Tito','476',NULL,NULL);
insert  into `empresa`(`Id`,`Cnpj`,`InscEstadual`,`InscMunicipal`,`RazaoSocial`,`Apelido`,`Logomarca`,`Cep`,`Bairro`,`Logradouro`,`Numero`,`Site`,`Email`) values (695,'19421097000134','4780563276807',NULL,'Natália e Mariana Entregas Expressas Ltda',NULL,NULL,36052260,'Grajaú','Travessa João Brun','754',NULL,NULL);
insert  into `empresa`(`Id`,`Cnpj`,`InscEstadual`,`InscMunicipal`,`RazaoSocial`,`Apelido`,`Logomarca`,`Cep`,`Bairro`,`Logradouro`,`Numero`,`Site`,`Email`) values (696,'61321906000100','280977140',NULL,'Diogo e Raul Alimentos Ltda',NULL,NULL,79042549,'Tiradentes','Travessa Moana','623',NULL,NULL);
insert  into `empresa`(`Id`,`Cnpj`,`InscEstadual`,`InscMunicipal`,`RazaoSocial`,`Apelido`,`Logomarca`,`Cep`,`Bairro`,`Logradouro`,`Numero`,`Site`,`Email`) values (697,'46146882000107','287872246',NULL,'Felipe e Débora Padaria ME',NULL,NULL,79094460,'Jardim Batistão','Rua Síria','279',NULL,NULL);
insert  into `empresa`(`Id`,`Cnpj`,`InscEstadual`,`InscMunicipal`,`RazaoSocial`,`Apelido`,`Logomarca`,`Cep`,`Bairro`,`Logradouro`,`Numero`,`Site`,`Email`) values (698,'72495689000183','419220968',NULL,'Emily e Davi Mudanças ME',NULL,NULL,29042650,'Fradinhos','Rua Professora Maria Acciolina Pereira','738',NULL,NULL);

/*Table structure for table `encomenda` */

DROP TABLE IF EXISTS `encomenda`;

CREATE TABLE `encomenda` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClienteId` int(11) NOT NULL,
  `EmpresaId` int(11) NOT NULL,
  `DataPedido` datetime NOT NULL,
  `DataEntrega` datetime DEFAULT NULL,
  `Peso` double NOT NULL,
  `Valor` decimal(10,0) NOT NULL,
  `QuantPacotes` int(11) NOT NULL,
  `status` int(2) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_encomenda_cliente1_idx` (`ClienteId`),
  KEY `fk_encomenda_empresa1_idx` (`EmpresaId`),
  CONSTRAINT `fk_encomenda_cliente1` FOREIGN KEY (`ClienteId`) REFERENCES `cliente` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_encomenda_empresa1` FOREIGN KEY (`EmpresaId`) REFERENCES `empresa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `encomenda` */

/*Table structure for table `estado` */

DROP TABLE IF EXISTS `estado`;

CREATE TABLE `estado` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PaisId` int(11) NOT NULL,
  `CodIbge` int(2) NOT NULL,
  `Nome` varchar(20) NOT NULL,
  `Sigla` varchar(2) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_estado_pais_idx` (`PaisId`),
  CONSTRAINT `fk_estado_pais` FOREIGN KEY (`PaisId`) REFERENCES `pais` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `estado` */

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `estoque` */

/*Table structure for table `forma` */

DROP TABLE IF EXISTS `forma`;

CREATE TABLE `forma` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

/*Data for the table `forma` */

insert  into `forma`(`Id`,`Nome`) values (1,'FORMA 1');
insert  into `forma`(`Id`,`Nome`) values (2,'FORMA 2');
insert  into `forma`(`Id`,`Nome`) values (3,'FORMA 3');
insert  into `forma`(`Id`,`Nome`) values (4,'FORMA 4');

/*Table structure for table `funcao` */

DROP TABLE IF EXISTS `funcao`;

CREATE TABLE `funcao` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(45) NOT NULL,
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
  CONSTRAINT `fk_funcao_usuario_funcao1` FOREIGN KEY (`funcaoId`) REFERENCES `funcao` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_funcao_usuario_usuario1` FOREIGN KEY (`usuarioId`) REFERENCES `usuario` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `funcao_usuario` */

/*Table structure for table `local` */

DROP TABLE IF EXISTS `local`;

CREATE TABLE `local` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClienteId` int(11) NOT NULL,
  `Cep` int(8) NOT NULL,
  `Logradouro` varchar(60) NOT NULL,
  `Bairro` varchar(45) NOT NULL,
  `Numero` varchar(20) DEFAULT NULL,
  `Complemento` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_local_cliente1_idx` (`ClienteId`),
  CONSTRAINT `fk_local_cliente1` FOREIGN KEY (`ClienteId`) REFERENCES `cliente` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `local` */

/*Table structure for table `maquina` */

DROP TABLE IF EXISTS `maquina`;

CREATE TABLE `maquina` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `maquina` */

insert  into `maquina`(`Id`,`Nome`) values (1,'MAQUINA 1');
insert  into `maquina`(`Id`,`Nome`) values (2,'MAQUINA 2');
insert  into `maquina`(`Id`,`Nome`) values (3,'MAQUINA 3');

/*Table structure for table `metadado` */

DROP TABLE IF EXISTS `metadado`;

CREATE TABLE `metadado` (
  `Tipo` varchar(20) NOT NULL,
  `Metadado` varchar(20) NOT NULL,
  `Conteudo` varchar(45) NOT NULL,
  KEY `fk_tipo_metadado` (`Tipo`,`Metadado`),
  CONSTRAINT `fk_tipo_metadado` FOREIGN KEY (`Tipo`, `Metadado`) REFERENCES `tipo` (`Tipo`, `Metadado`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `metadado` */

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
  CONSTRAINT `fk_encomenda_has_tipo_massa_encomenda1` FOREIGN KEY (`EncomendaId`) REFERENCES `encomenda` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_encomenda_has_tipo_massa_tipo_massa1` FOREIGN KEY (`TipoMassaId`) REFERENCES `tipo_massa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `pacotes` */

/*Table structure for table `pais` */

DROP TABLE IF EXISTS `pais`;

CREATE TABLE `pais` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CodPais` int(4) NOT NULL,
  `Nome` varchar(45) NOT NULL,
  `Sigla` varchar(3) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `pais` */

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
  CONSTRAINT `fk_telefone_cliente1` FOREIGN KEY (`ClienteId`) REFERENCES `cliente` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_telefone_empresa1` FOREIGN KEY (`EmpresaId`) REFERENCES `empresa` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `telefone` */

/*Table structure for table `tipo` */

DROP TABLE IF EXISTS `tipo`;

CREATE TABLE `tipo` (
  `Tipo` varchar(20) NOT NULL,
  `Metadado` varchar(20) NOT NULL,
  PRIMARY KEY (`Tipo`,`Metadado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tipo` */

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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*Data for the table `tipo_massa` */

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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

/*Data for the table `unidade_medida` */

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

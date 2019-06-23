CREATE DATABASE IF NOT EXISTS bancolegal
DEFAULT CHARACTER SET utf8
DEFAULT COLLATE utf8_general_ci;
 
USE bancolegal;

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS `CONTA`;  
DROP TABLE IF EXISTS `OPERACAO`;  
DROP TABLE IF EXISTS `PESSOA`;
DROP TABLE IF EXISTS `SESSAO`;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE PESSOA (
    ID INT NOT NULL AUTO_INCREMENT,
    NOME VARCHAR(100),
    EMAIL VARCHAR(100),  
    CPF VARCHAR(11), 
    DATANASCIMENTO DATE, 
    ENDERECO VARCHAR(100),
    PRIMARY KEY (ID));

CREATE TABLE CONTA (
    ID INT NOT NULL AUTO_INCREMENT,
    NUMERO INT, 
    AGENCIA INT, 
    TITULAR INT, 
    SENHA VARCHAR(30), 
    SALDO DECIMAL, 
    LIMITE DECIMAL, 
    STATUS BOOLEAN, 
    TIPO INT,
    PRIMARY KEY (ID),
    FOREIGN KEY (TITULAR) REFERENCES PESSOA(ID));

CREATE TABLE OPERACAO (
    ID INT NOT NULL AUTO_INCREMENT, 
    TIPO INT, 
    VALOR DECIMAL, 
    DATA DATE, 
    ORIGEM INT, 
    DESTINO INT,
    PRIMARY KEY (ID),
    FOREIGN KEY (ORIGEM) REFERENCES CONTA(ID),
    FOREIGN KEY (DESTINO) REFERENCES CONTA(ID));

CREATE TABLE SESSAO (
    ID INT NOT NULL AUTO_INCREMENT,
    IDCONTA INT,
    TOKEN VARCHAR(40),
    INTER INT,
    PRIMARY KEY (ID),
    FOREIGN KEY (IDCONTA) REFERENCES CONTA(ID)
);

CREATE  UNIQUE INDEX index_email ON PESSOA(EMAIL);
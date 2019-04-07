CREATE DATABASE IF NOT EXISTS bancolegal
DEFAULT CHARACTER SET utf8
DEFAULT COLLATE utf8_general_ci;
 
USE bancolegal;

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS `CONTA`;  
DROP TABLE IF EXISTS `OPERACAO`;  
DROP TABLE IF EXISTS `PESSOA`;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE CONTA (ID VARCHAR(40), NUMERO INT, AGENCIA INT, TITULAR VARCHAR(40), SENHA INT, SALDO DECIMAL, LIMITE DECIMAL, STATUS BOOLEAN);
CREATE TABLE OPERACAO (ID VARCHAR(40), TIPO INT, VALOR INT, DATA DATE, SENHA INT, ORIGEM VARCHAR(40), DESTINO VARCHAR(40));
CREATE TABLE PESSOA (ID VARCHAR(40), NOME VARCHAR(100), CPF VARCHAR(11), DATANASCIMENTO DATE, ENDERECO VARCHAR(100));
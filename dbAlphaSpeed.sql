CREATE DATABASE DBALPHASPEED;

USE DBALPHASPEED;

CREATE TABLE tbEnderecoCli (
cdEndereco INT PRIMARY KEY AUTO_INCREMENT,
nmLogradouro VARCHAR(40) NOT NULL,
noLogradouro VARCHAR(10) NOT NULL,
sgUf CHAR(2) NOT NULL,
nmCidade VARCHAR(40) NOT NULL,
nmBairro VARCHAR(40) NOT NULL,
dsComplemento VARCHAR(100)
);

create table tbCliente (
cdCli INT PRIMARY KEY AUTO_INCREMENT,
nmNome VARCHAR(30) NOT NULL,
nmSobrenome VARCHAR(30) NOT NULL,
dtNascimento DATE NOT NULL,
cdEndereco INT NOT NULL,
FOREIGN KEY (cdEndereco)
	REFERENCES tbEnderecoCli(cdEndereco)
);

CREATE TABLE tbLogin (
cdLogin INT PRIMARY KEY AUTO_INCREMENT,
nmUsuario VARCHAR(30) NOT NULL,
dsSenha VARCHAR(15) NOT NULL
);

CREATE TABLE tbVeiculo (
cdVeiculo int PRIMARY KEY AUTO_INCREMENT,
nmFabricante varchar(40) NOT NULL, 
nmModelo varchar(30) NOT NULL,
dsTipo varchar(20) NOT NULL,
dtFabricacao char(4) NOT NULL,
noPlaca char(8) NOT NULL,
vlPreco varchar(20) NOT NULL,
dsCor varchar(20) NOT NULL,
dsDescricao varchar(100)
);             
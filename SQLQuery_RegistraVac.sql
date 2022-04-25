CREATE DATABASE RegistraVac;

USE RegistraVac;

CREATE TABLE pessoas(id int primary key identity,
					nome varchar(50) not null,
					cpf varchar(11) not null,
					telefone varchar(15),
					nascimento varchar(10),
					cep int, endereco varchar(50),
					complemento varchar(50), numero int,
					vacina varchar(20),
					lote varchar(10),
					data_aplicação varchar(20));





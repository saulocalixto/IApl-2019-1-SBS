USE bancolegal;

Insert into PESSOA (ID, NOME, EMAIL,CPF, DATANASCIMENTO, ENDERECO) Values (1, 'Saulo Calixto', 'saulo@gmail.com', '28433978047', '1990-09-17', 'Rua Vitoria Régia n 30');
Insert into PESSOA (ID, NOME, EMAIL,CPF, DATANASCIMENTO, ENDERECO) Values (2, 'Cezar Calixto', 'cezar@gmail.com', '14723602062', '1990-09-18', 'Rua Vitoria Régia n 31');
Insert into PESSOA (ID, NOME, EMAIL,CPF, DATANASCIMENTO, ENDERECO) Values (3, 'Gessika Mikaele', 'gessika@gmail.com', '90400606062', '1990-09-19', 'Rua Vitoria Régia n 32');
Insert into PESSOA (ID, NOME, EMAIL,CPF, DATANASCIMENTO, ENDERECO) Values (4, 'Amanda Pereira', 'amanda@gmail.com', '61606806092', '1990-09-20', 'Rua Vitoria Régia n 33');
Insert into PESSOA (ID, NOME, EMAIL,CPF, DATANASCIMENTO, ENDERECO) Values (5, 'Valkiria Pereira', 'val@gmail.com', '35429995045', '1990-09-21', 'Rua Vitoria Régia n 34');

Insert into CONTA (ID, NUMERO, AGENCIA, TITULAR, SENHA, SALDO, LIMITE, STATUS, TIPO) Values (1, 12345678, 854, 1, '1234admin', 100000, 755555, TRUE, 1);
Insert into CONTA (ID, NUMERO, AGENCIA, TITULAR, SENHA, SALDO, LIMITE, STATUS, TIPO) Values (2, 859542654, 358, 2, 'admin123', 100, 200, FALSE, 1);
Insert into CONTA (ID, NUMERO, AGENCIA, TITULAR, SENHA, SALDO, LIMITE, STATUS, TIPO) Values (3, 546546565, 256, 3, 'maria123', 895, 100, FALSE, 1);
Insert into CONTA (ID, NUMERO, AGENCIA, TITULAR, SENHA, SALDO, LIMITE, STATUS, TIPO) Values (4, 6633565, 854, 4, 'MB1randa', 2295, 55, TRUE, 1);
Insert into CONTA (ID, NUMERO, AGENCIA, TITULAR, SENHA, SALDO, LIMITE, STATUS, TIPO) Values (5, 546552, 3185, 5, 'calixto', 85546, 225, FALSE, 1);

Insert into OPERACAO (ID, TIPO, VALOR, DATA, ORIGEM, DESTINO) Values (1, 1, 500, '2019-01-01', 1, 2);
Insert into OPERACAO (ID, TIPO, VALOR, DATA, ORIGEM, DESTINO) Values (2, 2, 358, '2019-01-03', 2, 2);
Insert into OPERACAO (ID, TIPO, VALOR, DATA, ORIGEM, DESTINO) Values (3, 1, 256, '2019-05-05', 2, 4);
Insert into OPERACAO (ID, TIPO, VALOR, DATA, ORIGEM, DESTINO) Values (4, 2, 900, '2019-02-03', 3, 3);
Insert into OPERACAO (ID, TIPO, VALOR, DATA, ORIGEM, DESTINO) Values (5, 2, 100, '2019-02-03', 3, 3);
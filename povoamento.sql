USE [ambrosium_bd];
GO

DELETE FROM Utilizador;
DELETE FROM Produto;
DELETE FROM Regime;

INSERT INTO Regime VALUES ('Sem regime especial');
INSERT INTO Regime VALUES ('Vegetariano');
INSERT INTO Regime VALUES ('Vegan');

INSERT INTO Utilizador VALUES ('Marcelo Miranda', 'a74817@uminho.pt', '', 0, 0, NULL, 0, 'Sem regime especial');

INSERT INTO Produto VALUES ('Francesinha', '', 1, 'Sem regime especial', 1);
INSERT INTO Produto VALUES ('Francesinha Grande', '', 2, 'Sem regime especial', 1);
INSERT INTO Produto VALUES ('Francesinha Pequena', '', 3, 'Sem regime especial', 1);
INSERT INTO Produto VALUES ('Francesinha Gigante', '', 4, 'Sem regime especial', 1);
INSERT INTO Produto VALUES ('Real Francesinha', '', 5, 'Sem regime especial', 1);
INSERT INTO Produto VALUES ('Uma Francesinha', '', 6, 'Sem regime especial', 1);
INSERT INTO Produto VALUES ('Francesinha de Braga', '', 7, 'Sem regime especial', 1);
INSERT INTO Produto VALUES ('Francesinha do Porto', '', 8, 'Sem regime especial', 1);
INSERT INTO Produto VALUES ('Meia Francesinha', '', 9, 'Sem regime especial', 1);
INSERT INTO Produto VALUES ('Francesinha Vegetariana', '', 9, 'Vegetariano', 1);

GO
USE [ambrosium_bd];
GO

DELETE FROM Regime;
DELETE FROM Utilizador;

INSERT INTO Regime VALUES ('Sem regime especial');
INSERT INTO Regime VALUES ('Vegetariano');
INSERT INTO Regime VALUES ('Vegan');

INSERT INTO Utilizador VALUES ('Marcelo Miranda', 'a74817@uminho.pt', '', 0, 0, NULL, 0, 'Sem regime especial');

GO
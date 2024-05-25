
-- Inserir dados na tabela Clientes
INSERT INTO Clientes (Cpf, Nome, SobreNome, Email, NomeSocial, DataCadastro)
VALUES
('12345678909', 'Joao', 'Silva', 'joao.silva1@example.com', 'João S.', GETDATE()),
('23456789012', 'Maria', 'Lima', 'maria.lima2@example.com', 'Maria L.', GETDATE()),
('34567890123', 'Carlos', 'Santos', 'carlos.santos3@example.com', 'Carlos S.', GETDATE()),
('45678901234', 'Ana', 'Souza', 'ana.souza4@example.com', 'Ana S.', GETDATE()),
('56789012345', 'Pedro', 'Almeida', 'pedro.almeida5@example.com', 'Pedro A.', GETDATE()),
('67890123456', 'Lucia', 'Ferreira', 'lucia.ferreira6@example.com', 'Lucia F.', GETDATE()),
('78901234567', 'Marcos', 'Rocha', 'marcos.rocha7@example.com', 'Marcos R.', GETDATE()),
('89012345678', 'Paula', 'Mendes', 'paula.mendes8@example.com', 'Paula M.', GETDATE()),
('90123456789', 'Rafael', 'Costa', 'rafael.costa9@example.com', 'Rafael C.', GETDATE()),
('01234567890', 'Beatriz', 'Barbosa', 'beatriz.barbosa0@example.com', 'Beatriz B.', GETDATE());
GO

-- Inserir dados na tabela Combos
INSERT INTO Combos (Nome)
VALUES
('Combo Cheeseburger'),
('Combo Hamburger'),
('Combo Chicken Sandwich'),
('Combo Veggie Burger'),
('Combo Fish Sandwich'),
('Combo Double Cheeseburger'),
('Combo Bacon Burger'),
('Combo Chicken Nuggets'),
('Combo Hot Dog'),
('Combo BBQ Burger');
GO

-- Inserir dados na tabela Pedidos
INSERT INTO Pedidos (ClienteId, PedidoStatusId, PedidoPagamentoId, DataPedido, DataAtualizacao)
VALUES
(1, 1, 1, GETDATE(), NULL),
(2, 2, 2, GETDATE(), NULL),
(3, 3, 3, GETDATE(), NULL),
(4, 1, 1, GETDATE(), NULL),
(5, 2, 2, GETDATE(), NULL),
(6, 3, 3, GETDATE(), NULL),
(7, 1, 1, GETDATE(), NULL),
(8, 2, 2, GETDATE(), NULL),
(9, 3, 3, GETDATE(), NULL),
(10, 1, 1, GETDATE(), NULL);
GO

-- Inserir dados na tabela Produtos
INSERT INTO Produtos (CategoriaId, Nome, Preco, Status, PedidoId)
VALUES
-- Lanches
(1, 'Cheeseburger', 8.50, 1, 1),
(1, 'Hamburger', 7.00, 1, 2),
(1, 'Chicken Sandwich', 9.00, 1, 3),
(1, 'Veggie Burger', 9.50, 1, 4),
(1, 'Fish Sandwich', 8.00, 1, 5),
(1, 'Double Cheeseburger', 10.00, 1, 6),
(1, 'Bacon Burger', 9.75, 1, 7),
(1, 'Chicken Nuggets', 5.50, 1, 8),
(1, 'Hot Dog', 4.00, 1, 9),
(1, 'BBQ Burger', 9.25, 1, 10),
-- Bebidas
(2, 'Coca-Cola', 3.00, 1, 1),
(2, 'Pepsi', 3.00, 1, 2),
(2, 'Sprite', 3.00, 1, 3),
(2, 'Fanta', 3.00, 1, 4),
(2, 'Água Mineral', 2.00, 1, 5),
(2, 'Suco de Laranja', 4.00, 1, 6),
(2, 'Chá Gelado', 3.50, 1, 7),
(2, 'Café', 2.50, 1, 8),
(2, 'Milkshake', 5.00, 1, 9),
(2, 'Cerveja', 6.00, 1, 10),
-- Sobremesas
(3, 'Sorvete', 3.50, 1, 1),
(3, 'Torta de Maçã', 4.00, 1, 2),
(3, 'Brownie', 4.50, 1, 3),
(3, 'Mousse de Chocolate', 5.00, 1, 4),
(3, 'Pudim', 3.50, 1, 5),
(3, 'Cheesecake', 5.50, 1, 6),
(3, 'Petit Gâteau', 6.00, 1, 7),
(3, 'Cupcake', 3.00, 1, 8),
(3, 'Milkshake de Morango', 5.00, 1, 9),
(3, 'Banana Split', 6.50, 1, 10),
-- Acompanhamentos
(4, 'Batata Frita', 3.50, 1, 1),
(4, 'Onion Rings', 4.00, 1, 2),
(4, 'Salada', 5.00, 1, 3),
(4, 'Mozzarella Sticks', 5.50, 1, 4),
(4, 'Coleslaw', 3.00, 1, 5),
(4, 'Chicken Wings', 7.00, 1, 6),
(4, 'Nachos', 6.50, 1, 7),
(4, 'Quesadilla', 6.00, 1, 8),
(4, 'Pão de Alho', 4.00, 1, 9),
(4, 'Bruschetta', 5.50, 1, 10);
GO


-- Inserir dados na tabela ComboProdutos
INSERT INTO ComboProdutos (ProdutoId, ComboId)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10),
(11, 1), -- Adicionando bebidas aos combos
(12, 2),
(13, 3),
(14, 4),
(15, 5),
(16, 6),
(17, 7),
(18, 8),
(19, 9),
(20, 10),
(21, 1), -- Adicionando sobremesas aos combos
(22, 2),
(23, 3),
(24, 4),
(25, 5),
(26, 6),
(27, 7),
(28, 8),
(29, 9),
(30, 10),
(31, 1), -- Adicionando acompanhamentos aos combos
(32, 2),
(33, 3),
(34, 4),
(35, 5),
(36, 6),
(37, 7),
(38, 8),
(39, 9),
(40, 10);
GO

-- Inserir dados na tabela PedidoProdutos
INSERT INTO PedidoProdutos (Quantidade, ProdutoId, PedidoId, ComboId)
VALUES
(2, 1, 1, 1),
(1, 2, 2, 2),
(3, 3, 3, 3),
(1, 4, 4, 4),
(2, 5, 5, 5),
(1, 6, 6, 6),
(3, 7, 7, 7),
(1, 8, 8, 8),
(2, 9, 9, 9),
(1, 10, 10, 10),
(1, 11, 1, 1), -- Adicionando bebidas aos pedidos
(1, 12, 2, 2),
(1, 13, 3, 3);


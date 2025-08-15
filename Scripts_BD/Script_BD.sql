-- 1. Excluir tabelas (respeitando FK)
IF OBJECT_ID('dbo.Transacoes', 'U') IS NOT NULL
    DROP TABLE dbo.Transacoes;

IF OBJECT_ID('dbo.Categorias', 'U') IS NOT NULL
    DROP TABLE dbo.Categorias;

-- 2. Criar tabela Categorias
CREATE TABLE dbo.Categorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    Tipo NVARCHAR(20) NOT NULL CHECK (Tipo IN ('Receita', 'Despesa')),
    Ativo BIT NOT NULL DEFAULT(1)
);

-- 3. Criar tabela Transacoes
CREATE TABLE dbo.Transacoes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Descricao NVARCHAR(250) NOT NULL,
    Valor DECIMAL(18, 2) NOT NULL CHECK (Valor > 0),
    Data DATE NOT NULL CHECK (Data <= CAST(GETDATE() AS DATE)),
    CategoriaId INT NOT NULL,
    Observacoes NVARCHAR(500) NULL,
    DataCriacao DATETIME NOT NULL DEFAULT(GETDATE()),
    CONSTRAINT FK_Transacoes_Categorias FOREIGN KEY (CategoriaId) REFERENCES dbo.Categorias(Id)
);

-- 4. Inserir dados iniciais

INSERT INTO Categorias (Nome, Tipo) VALUES
('Salário', 'Receita'),
('Venda de Produto', 'Receita'),
('Aluguel', 'Despesa'),
('Energia Elétrica', 'Despesa'),
('Alimentação', 'Despesa'),
('Transporte', 'Despesa'),
('Educação', 'Despesa'),
('Saúde', 'Despesa'),
('Lazer', 'Despesa'),
('Outros', 'Despesa');

INSERT INTO Transacoes (Descricao, Valor, Data, CategoriaId) VALUES
('Pagamento Salário Agosto', 5000.00, '2025-08-01', 1),
('Venda de produto A', 1200.00, '2025-08-05', 2),
('Pagamento Aluguel', 1500.00, '2025-08-08', 3),
('Conta de Luz', 300.00, '2025-08-09', 4),
('Compra no supermercado', 250.75, '2025-08-01', 5),
('Passagem de ônibus', 4.50, '2025-08-02', 6),
('Mensalidade curso inglês', 300.00, '2025-08-05', 7),
('Consulta médica', 180.00, '2025-08-03', 8),
('Cinema', 45.00, '2025-08-07', 9),
('Compra presente', 120.00, '2025-08-08', 10);




select * from Categorias;
select * from Transacoes;
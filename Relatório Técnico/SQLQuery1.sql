CREATE DATABASE dbClinicaOdontologica;
GO

USE dbClinicaOdontologica;
GO

-- 1. TABELA USUARIO
CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Login VARCHAR(100) NOT NULL UNIQUE,
    Senha VARCHAR(255) NOT NULL
);
GO

-- 2. TABELA PACIENTE
CREATE TABLE Paciente (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NomeCompleto VARCHAR(150) NOT NULL,
    CPF VARCHAR(11) NOT NULL UNIQUE,
    Telefone VARCHAR(20) NOT NULL,
    Email VARCHAR(150) NULL
);
GO

-- 3. TABELA PROCEDIMENTO (Obrigatoriamente associado a um Paciente)
CREATE TABLE Procedimento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NomeProcedimento VARCHAR(120) NOT NULL,
    Descricao VARCHAR(255) NULL,
    Valor DECIMAL(10,2) NOT NULL,
    PacienteId INT NOT NULL,

    CONSTRAINT FK_Procedimento_Paciente
        FOREIGN KEY (PacienteId) REFERENCES Paciente(Id)
);
GO

-- 4. TABELA AGENDAMENTO (Relaciona Paciente e Procedimento com Data)
CREATE TABLE Agendamento (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DataConsulta DATETIME2 NOT NULL,
    Observacoes VARCHAR(255) NULL,
    PacienteId INT NOT NULL,
    ProcedimentoId INT NOT NULL,

    CONSTRAINT FK_Agendamento_Paciente
        FOREIGN KEY (PacienteId) REFERENCES Paciente(Id),

    CONSTRAINT FK_Agendamento_Procedimento
        FOREIGN KEY (ProcedimentoId) REFERENCES Procedimento(Id)
);
GO

-- POPULAÇÃO DO BANCO (Mínimo 3 registros por tabela)
INSERT INTO Usuario (Nome, Login, Senha) VALUES
('Dr. Carlos Mendes', 'carlos', '123456'),
('Recepção Ana', 'ana', '123456'),
('Administrador', 'admin', 'admin123');
GO

INSERT INTO Paciente (NomeCompleto, CPF, Telefone, Email) VALUES
('Fernanda Lima', '11122233344', '79999991111', 'fernanda@email.com'),
('Ricardo Santos', '22233344455', '79999992222', 'ricardo@email.com'),
('Juliana Costa', '33344455566', '79999993333', 'juliana@email.com');
GO

INSERT INTO Procedimento (NomeProcedimento, Descricao, Valor, PacienteId) VALUES
('Limpeza e Profilaxia', 'Remoção de tártaro e polimento', 180.00, 1),
('Restauração em Resina', 'Dente molar superior direito', 250.00, 2),
('Tratamento de Canal', 'Endodontia pré-molar', 650.00, 3);
GO

INSERT INTO Agendamento (DataConsulta, Observacoes, PacienteId, ProcedimentoId) VALUES
('2026-11-20 09:00:00', 'Primeira avaliação e limpeza', 1, 1),
('2026-11-21 14:30:00', 'Retorno para restauração', 2, 2),
('2026-11-22 10:15:00', 'Sessão inicial de canal', 3, 3);
GO
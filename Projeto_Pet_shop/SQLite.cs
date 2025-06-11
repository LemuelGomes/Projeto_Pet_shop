using System;
using System.Data.SQLite;
using System.IO;

namespace Projeto_Pet_shop
{
    internal static class ClassSQLite
    {
        private static readonly string caminhoArquivo =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "loja_pet_shop.db");

        private static readonly string connectionString =
            $"Data Source={caminhoArquivo};Version=3;";

        public static SQLiteConnection conexao;
        public static SQLiteCommand comando;

        static ClassSQLite()
        {
            bool criarBanco = !File.Exists(caminhoArquivo);
            conexao = new SQLiteConnection(connectionString);
            comando = new SQLiteCommand(conexao);

            if (criarBanco)
            {
                conexao.Open();

                string scriptInicial = @"
PRAGMA foreign_keys = ON;

-- --------------------------------------------------------
-- Tabela: tbl_pessoa
-- --------------------------------------------------------
CREATE TABLE IF NOT EXISTS tbl_pessoa (
  id_pessoa   INTEGER PRIMARY KEY AUTOINCREMENT,
  nome        TEXT    NOT NULL,
  sobrenome   TEXT    NOT NULL,
  email       TEXT    NOT NULL UNIQUE,
  cpf         TEXT    NOT NULL,
  senha       TEXT    NOT NULL
);

-- Insere somente Lemuel Gomes
INSERT INTO tbl_pessoa (id_pessoa, nome, sobrenome, email, cpf, senha) VALUES
  (1, 'Padrão', 'Padrão', '123', 'Padrão', '123');

-- --------------------------------------------------------
-- Tabela: tbl_colaborador
-- --------------------------------------------------------
CREATE TABLE IF NOT EXISTS tbl_colaborador (
  id_colaborador   INTEGER PRIMARY KEY AUTOINCREMENT,
  data_admissao    TEXT    NOT NULL,
  data_demissao    TEXT    DEFAULT NULL,
  departamento     TEXT    NOT NULL,
  cargo            TEXT    NOT NULL,
  fk_pessoa        INTEGER NOT NULL,
  FOREIGN KEY(fk_pessoa) REFERENCES tbl_pessoa(id_pessoa)
);

-- Insere um colaborador padrão admitido em 2025-06-22
INSERT INTO tbl_colaborador (id_colaborador, data_admissao, data_demissao, departamento, cargo, fk_pessoa) VALUES
  (1, '2025-06-22', NULL, 'ADM', 'CEO', 1);

-- --------------------------------------------------------
-- Tabela: tbl_pagamento
-- --------------------------------------------------------
CREATE TABLE IF NOT EXISTS tbl_pagamento (
  id_pagamento   INTEGER PRIMARY KEY AUTOINCREMENT,
  data_pagamento TEXT    NOT NULL,
  tipo_pagamento TEXT    NOT NULL,
  valor_total    REAL    NOT NULL,
  fk_colaborador INTEGER NOT NULL,
  FOREIGN KEY(fk_colaborador) REFERENCES tbl_colaborador(id_colaborador)
);

-- Não há registros iniciais de pagamento

-- --------------------------------------------------------
-- Tabela: tbl_venda
-- --------------------------------------------------------
CREATE TABLE IF NOT EXISTS tbl_venda (
  id_venda       INTEGER PRIMARY KEY AUTOINCREMENT,
  data_venda     TEXT    NOT NULL,
  carrinho       TEXT    NOT NULL,
  fk_colaborador INTEGER NOT NULL,
  FOREIGN KEY(fk_colaborador) REFERENCES tbl_colaborador(id_colaborador)
);

-- Não há registros iniciais de venda

-- --------------------------------------------------------
-- Tabela: tbl_produtos
-- --------------------------------------------------------
CREATE TABLE IF NOT EXISTS tbl_produtos (
  id                  INTEGER PRIMARY KEY AUTOINCREMENT,
  descricao_produto   TEXT    NOT NULL,
  categoria_produto   TEXT    NOT NULL,
  quantidade_produto  INTEGER NOT NULL DEFAULT 0,
  preco_custo         REAL    NOT NULL,
  preco_produto       REAL    NOT NULL,
  fk_colaborador      INTEGER NOT NULL,
  fk_pagamento        INTEGER DEFAULT NULL,
  FOREIGN KEY(fk_colaborador) REFERENCES tbl_colaborador(id_colaborador),
  FOREIGN KEY(fk_pagamento)   REFERENCES tbl_pagamento(id_pagamento)
);

-- Não há registros iniciais de produtos
";

                using (var cmd = new SQLiteCommand(scriptInicial, conexao))
                {
                    cmd.ExecuteNonQuery();
                }

                conexao.Close();
            }
        }
    }
}
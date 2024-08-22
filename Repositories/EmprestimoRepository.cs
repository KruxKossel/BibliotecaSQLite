using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaSQLite.Models;

namespace BibliotecaSQLite.Repositories
{
    public class EmprestimoRepository(string connectionString) : IRepository<Emprestimo> 
    {

        private readonly string _connectionString = connectionString;

        public void Adicionar(Emprestimo entidade)
        {

            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("INSERT INTO emprestimos (livroId, usuarioId, dataEmprestimo, dataDevolucao) VALUES (@livroId, @usuarioId, @dataEmprestimo, @dataDevolucao)", connection);
            command.Parameters.AddWithValue("@livroId", entidade.LivroId);
            command.Parameters.AddWithValue("@usuarioId", entidade.UsuarioId);
            command.Parameters.AddWithValue("@dataEmprestimo", entidade.DataEmprestimo);
            command.Parameters.AddWithValue("@dataDevolucao", entidade.DataDevolucao.HasValue ? (object)entidade.DataDevolucao.Value : DBNull.Value);
            command.ExecuteNonQuery();

        }

        public Emprestimo GetById(int id)
        {

            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            var command = new SQLiteCommand("SELECT * FROM emprestimos WHERE id = @id", connection); // linha de comando e conexão
            command.Parameters.AddWithValue("@id", id); // Coleta o parametro fornecido ao método e o converte para valor
            
            // Esse método ExecuteReader() é da classe SQLiteCommand, mas ele é do tipo SQLiteDataReader, que é outra Classe,
            // essa classe permite ler o bd, diferente do SQLiteCommand, que manipula os dados
            // aqui abaixo é criado um obj do tipo SQLiteDataReader pq command.ExecuteReader() retorna um SQLiteDataReader
            // O comando (SQLiteCommand) solicita uma leitura dos dados eo SQLiteDataReader fornece as ferramentas
            using var reader = command.ExecuteReader();
            if (reader.Read()) // caso haja dados ele lê o bd
            {
                return new Emprestimo // cria um objt do tipo da entidade, que ira receber os dados do bd
                {
                    Id = reader.GetInt32(0),
                    LivroId = reader.GetInt32(1),
                    UsuarioId = reader.GetInt32(2),
                    DataEmprestimo = reader.GetDateTime(3),
                    DataDevolucao = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4)

                    // esse métodos usados pelo reader são da classe SQLiteDataReader, 
                    // são meio que conversores para trazer o dado no formato correto
                };
            }
            return null;

        }
        public IEnumerable<Emprestimo> GetAll()
        {

            var emprestimos = new List<Emprestimo>();
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM emprestimos", connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                emprestimos.Add(new Emprestimo // lista
                {
                    Id = reader.GetInt32(0),
                    LivroId = reader.GetInt32(1),
                    UsuarioId = reader.GetInt32(2),
                    DataEmprestimo = reader.GetDateTime(3),
                    DataDevolucao = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4)
                });
            }
            return emprestimos;

        }
        public void Update(Emprestimo entidade)
        {

            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("UPDATE emprestimos SET livroId = @livroId, usuarioId = @usuarioId, dataEmprestimo = @dataEmprestimo, dataDevolucao = @dataDevolucao WHERE id = @id", connection);
            command.Parameters.AddWithValue("@livroId", entidade.LivroId);
            command.Parameters.AddWithValue("@usuarioId", entidade.UsuarioId);
            command.Parameters.AddWithValue("@dataEmprestimo", entidade.DataEmprestimo);
            command.Parameters.AddWithValue("@dataDevolucao", entidade.DataDevolucao.HasValue ? (object)entidade.DataDevolucao.Value : DBNull.Value);
            command.Parameters.AddWithValue("@id", entidade.Id);
            command.ExecuteNonQuery();

        }
        public void Delete(int id)
        {

            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("DELETE FROM emprestimos WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }

}
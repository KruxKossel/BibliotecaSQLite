using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaSQLite.Models;

namespace BibliotecaSQLite.Repositories
{
    public class LivroRepository(string connectionString) : IRepository<Livro>
    {
        private readonly string _connectionString = connectionString;

        public void Adicionar(Livro entidade)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("INSERT INTO livros (titulo, autor, anoDePublicacao) VALUES (@titulo, @autor, @anoDePublicacao)", connection);
            command.Parameters.AddWithValue("@titulo", entidade.Titulo);
            command.Parameters.AddWithValue("@autor", entidade.Autor);
            command.Parameters.AddWithValue("@anoDePublicacao", entidade.AnoDePublicacao);
            command.ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("DELETE FROM livros WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public IEnumerable<Livro> GetAll()
        {
            var livros = new List<Livro>();
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM livros", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                livros.Add(new Livro
                {
                    Id = reader.GetInt32(0),
                    Titulo = reader.GetString(1),
                    Autor = reader.GetString(2),
                    AnoDePublicacao = reader.GetInt32(3)
                });
        }
        return livros;
        }

        public Livro GetById(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM livros WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Livro
                {
                    Id = reader.GetInt32(0),
                    Titulo = reader.GetString(1),
                    Autor = reader.GetString(2),
                    AnoDePublicacao = reader.GetInt32(3)
                };
            }
            return null;

        }

        public void Update(Livro entidade)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("UPDATE livros SET titulo = @titulo, autor = @autor, anoDePublicacao = @anoDePublicacao WHERE id = @id", connection);
            command.Parameters.AddWithValue("@titulo", entidade.Titulo);
            command.Parameters.AddWithValue("@autor", entidade.Autor);
            command.Parameters.AddWithValue("@anoDePublicacao", entidade.AnoDePublicacao);
            command.Parameters.AddWithValue("@id", entidade.Id);
            command.ExecuteNonQuery();

        }
    }
}
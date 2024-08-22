using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaSQLite.Models;

namespace BibliotecaSQLite.Repositories
{
    public class UsuarioRepository(string connectionString) : IRepository<Usuario>
    {
        private readonly string _connectionString = connectionString;

        public void Adicionar(Usuario entidade)
        {

            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("INSERT INTO usuarios (nome) VALUES (@nome)", connection);
            command.Parameters.AddWithValue("@nome", entidade.Nome);
            command.ExecuteNonQuery();

        }


        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("DELETE FROM usuarios WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            
        }

        public IEnumerable<Usuario> GetAll()
        {
            var usuarios = new List<Usuario>();
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM usuarios", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                usuarios.Add(new Usuario
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                });
            }
            return usuarios;

        }

        public Usuario GetById(int id)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("SELECT * FROM usuarios WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Usuario
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                };
            }
            return null;

        }

        public void Update(Usuario entidade)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            var command = new SQLiteCommand("UPDATE usuarios SET nome = @nome WHERE id = @id", connection);
            command.Parameters.AddWithValue("@nome", entidade.Nome);
            command.Parameters.AddWithValue("@id", entidade.Id);
            command.ExecuteNonQuery();

        }
    }
}
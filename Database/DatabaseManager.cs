using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaSQLite.Database
{
    // classe que cria as tabelas
    public class DatabaseManager(string connectionString) // recebe a connectionString do main
    {
        //string de conexão que dara o caminho para o bd 
        private readonly string _connectionString = connectionString;

        //Método com as configurações das tabelas
        public void InicializeDatabase(){

            // o USING serve para descartar o obejto após o término de sua operação, 
            // o VAR define o tipo do atributo/objeto de acordo com o que ele é igual
            using (var connection = new SQLiteConnection(_connectionString)) // cria um obj do tipo sqlite Conexão
            {
                connection.Open(); // abre a conexão que será fechado após o fim do bloco using (se não utilizar as chaves, fazer em formato de blocos, a conexão se encerra no fim do método)

                // Habilitar suporte a chaves estrangeiras
                using(var command = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection)){ // Cria um bjt do tipo sqlite Comando
                    command.ExecuteNonQuery(); //O método ExecuteNonQuery é usado para executar comandos SQL que não retornam resultados
                }

                // Abaixo está sendo criado atributos que possuem as informações e comandos para crias tabelas,
                // os atributos serão utilizados pela classe sqliteCommand para criar as tabelas, codigo mudular e tal tal tal

                string createUsuariosTableQuery = "CREATE TABLE IF NOT EXISTS usuarios (id INTEGER PRIMARY KEY, nome TEXT)";

                string createLivrosTableQuery = @"CREATE TABLE IF NOT EXISTS livros (
                                                                                        id INTEGER PRIMARY KEY, 
                                                                                        titulo TEXT, 
                                                                                        autor TEXT, 
                                                                                        anoDePublicacao INTEGER )";

                string createEmprestimosTableQuery = @"CREATE TABLE IF NOT EXISTS emprestimos (
                                                                                        id INTEGER PRIMARY KEY,
                                                                                        livroId INTEGER,
                                                                                        usuarioId INTEGER,
                                                                                        dataEmprestimo TEXT,
                                                                                        dataDevolucao TEXT,
                                                                                        FOREIGN KEY(livroId) REFERENCES livros(id),
                                                                                        FOREIGN KEY(usuarioId) REFERENCES usuarios(id))";

                // mesma lógica dos usings anteriores, instanciam os objetos para a criação das tabelas,
                // que serão descartados após o fim de sua execução                                                                        
                using(var commandUsuarios = new SQLiteCommand(createUsuariosTableQuery, connection)){ // primeiro parâmetro é a "entidade", segundo é a conexão que foi definida
                    commandUsuarios.ExecuteNonQuery();
                }
                 using(var commandLivros = new SQLiteCommand(createLivrosTableQuery, connection)){
                    commandLivros.ExecuteNonQuery();
                }
                using(var commandEmprestimos = new SQLiteCommand(createEmprestimosTableQuery, connection)){
                    commandEmprestimos.ExecuteNonQuery();
                }
            }
        }
    }
}
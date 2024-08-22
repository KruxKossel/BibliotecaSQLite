using System;
using BibliotecaSQLite.Models;
using BibliotecaSQLite.Repositories;
using BibliotecaSQLite.Configurations;
using BibliotecaSQLite.Database;
using BibliotecaSQLite.Helpers;
using System.Data.SQLite;
using BibliotecaSQLite;


// Define a string de conexão
string connectionString = "Data Source=" + DatabaseConfig.DatabasePath;


DatabaseManager dbManager = new DatabaseManager(connectionString);

// Cria as tabelas do bd
dbManager.InicializeDatabase();

// Repositórios

LivroRepository livroRepo = new LivroRepository(connectionString);
UsuarioRepository usuarioRepo = new UsuarioRepository(connectionString);
EmprestimoRepository emprestimoRepo = new EmprestimoRepository(connectionString);

// Adicionar dados

Usuario novoUsu = new Usuario(){
    Nome = "Pedro"
};

Livro novoLi = new Livro(){
    Titulo = "Sol Amarelo",
    Autor = "Deus",
    AnoDePublicacao = 666

};

// é necessario os id das chaves estrangeiras
Emprestimo novoEm = new Emprestimo(){
    UsuarioId = novoUsu.Id,
    LivroId = novoLi.Id,
    DataEmprestimo = DateTime.Now
};

//----------------------------------------------------------------------------

Usuario novoUsua = new Usuario(){
    Nome = "Ana"
};

Livro novoLiv = new Livro(){
    Titulo = "Sol Azul",
    Autor = "God",
    AnoDePublicacao = 999

};

Emprestimo novoEmp = new Emprestimo(){
    UsuarioId = novoUsua.Id,
    LivroId = novoLiv.Id,
    DataEmprestimo = DateTime.Now
};

//--------------------------------------------------------------------------------

livroRepo.Adicionar(novoLi);
usuarioRepo.Adicionar(novoUsu);
emprestimoRepo.Adicionar(novoEm);

livroRepo.Adicionar(novoLiv);
usuarioRepo.Adicionar(novoUsua);
emprestimoRepo.Adicionar(novoEmp);





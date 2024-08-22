using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


// exemplo - não sera usado (Apenas para estudo da aula)
namespace BibliotecaSQLite.Helpers
{
    public class DataTableHelper
    {
        public static DataTable CreateLivroDataTable(){

            DataTable table = new DataTable("Livros");

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Titulo", typeof(string));
            table.Columns.Add("Autor", typeof(string));
            table.Columns.Add("AnoDePublicacao", typeof(int));

            return table;
        }

        public static DataTable CreateUsuarioDataTable(){

            DataTable table = new DataTable("Usuarios");

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Nome", typeof(string));

            return table;
        }

        public static DataTable CreateEmprestimoDataTable(){

            DataTable table = new DataTable("Emprestimos");

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("LivroId", typeof(string));
            table.Columns.Add("UsuarioId", typeof(string));
            table.Columns.Add("DataEmprestimo", typeof(DateTime));
            table.Columns.Add("DataDevolucao", typeof(DateTime));

            return table;
        }
    }
}
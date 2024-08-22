using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaSQLite.Models
{
    public class Emprestimo//(int id, int livroId, int usuarioId, DateTime dataEmprestimo, DateTime dataDevolucao )
    {

        public int Id {get; set;} //= id;
        public int LivroId {get; set;}// = livroId;
        public int UsuarioId {get; set;} //= usuarioId;
        public DateTime DataEmprestimo {get; set;}//= dataEmprestimo;
        public DateTime? DataDevolucao {get; set;} //= dataDevolucao;
        
    }
}

// O construtor está comentado pq não será usado, 
//foi feito apenas para fins de estudo, 
//ele não é necessario em modelos, pode acarretar em erros e mau processamento de leitura
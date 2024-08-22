using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaSQLite.Models
{
    public class Livro//(int id, string titulo, string autor, int anoDePublicacao)
    {
        public int Id {get; set;}//= id;
        public string Titulo {get; set;} = string.Empty; //= titulo;
        public string Autor {get; set;} = string.Empty; //= autor;
        public int AnoDePublicacao {get; set;}//= anoDePublicacao;
        
    }
}

// string.Empty; -> é util para evitar strings nulas
//Não interfere na criação do bd,
// classes modelos servem apenas como moldes


// O construtor está comentado pq não será usado, 
//foi feito apenas para fins de estudo, 
//ele não é necessario em modelos, pode acarretar em erros e mau processamento de leitura
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaSQLite.Models
{
    public class Usuario//(int id, string nome)
    {
        public int Id {get; set;} //= id;
        public string Nome {get; set;} = string.Empty; //= nome;       
    }
}

// string.Empty; -> é util para evitar strings nulas
//Não interfere na criação do bd,
// classes modelos servem apenas como moldes


// O construtor está comentado pq não será usado, 
//foi feito apenas para fins de estudo, 
//ele não é necessario em modelos, pode acarretar em erros e mau processamento de leitura
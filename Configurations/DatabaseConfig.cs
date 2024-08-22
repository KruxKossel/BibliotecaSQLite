using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaSQLite.Configurations
{
    // Classe para facil manutenção do local do bd
    public class DatabaseConfig
    {
        //arquivo que está o bd/ onde ficara o bd após inicializado 
        public static string DatabasePath {get;} = "Database/Biblioteca.db";
        
    }
}
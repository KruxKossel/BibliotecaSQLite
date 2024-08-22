using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaSQLite.Repositories
{
    // Defini os métodos de CRUD que serão relizados 
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Realiza operação de INSERT
        /// </summary>
        /// <param name="entidade"></param>
        void Adicionar(T entidade);

        /// <summary>
        /// Seleciona uma tabela especifica,
        /// Realiza operação de SELECT * FROM entidade WHERE id = id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Seleciona todas as tabelas,
        /// Realiza operação de SELECT * FROM entidade
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Realiza operação de UPDATE 
        /// </summary>
        /// <param name="entidade"></param>
        void Update(T entidade);

        /// <summary>
        /// Realiza operação de DELETE FROM
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
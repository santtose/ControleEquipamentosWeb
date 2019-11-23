using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.DAL
{
    interface IRepository<T>
    {
        bool Cadastrar(T objeto);
        List<T> ListarTodos();
        T BuscarPorId(int? id);
    }
}

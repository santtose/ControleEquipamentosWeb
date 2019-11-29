using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEquipamentosWeb.Utils
{
    public class UtilsSession
    {
        private readonly IHttpContextAccessor _http;
        private readonly string EMPRESTIMO_EQUIPAMENTOS_ID = "emprestimoEquipamentosId";
        public UtilsSession(IHttpContextAccessor http)
        {
            _http = http;
        }
        public string RetonarËquipamentosParaEmprestimoId()
        {
            if (_http.HttpContext.Session.
                GetString(EMPRESTIMO_EQUIPAMENTOS_ID) == null)
            {
                _http.HttpContext.Session.SetString
                    (EMPRESTIMO_EQUIPAMENTOS_ID, Guid.NewGuid().ToString());
            }
            return _http.HttpContext.Session.
                GetString(EMPRESTIMO_EQUIPAMENTOS_ID);
        }
    }
}

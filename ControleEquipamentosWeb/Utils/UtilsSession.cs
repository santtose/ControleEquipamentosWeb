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
        private readonly string CESTA_ID = "cestaId";

        public UtilsSession(IHttpContextAccessor http)
        {
            _http = http;
        }

        public string RetornarCestaId()
        {
            if (_http.HttpContext.Session.GetString(CESTA_ID) == null)
            {
                _http.HttpContext.Session.SetString(CESTA_ID, Guid.NewGuid().ToString());
            }
            return _http.HttpContext.Session.GetString(CESTA_ID);
        }
    }
}

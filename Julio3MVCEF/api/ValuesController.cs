using Julio3MVCEF.Models;
using Julio3MVCEF.servicio.repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Julio3MVCEF.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // api/Values/Listar
        public List<Customer> Listar()
        {
            return CustomerRepo.ListarTodo();
        }
    }
}

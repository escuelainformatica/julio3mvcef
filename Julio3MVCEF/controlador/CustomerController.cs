using Julio3MVCEF.Models;
using Julio3MVCEF.servicio.repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Julio3MVCEF.controlador
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {

            List<Customer> clientes=CustomerRepo.ListarPaginado(0);
            // ViewBag, ViewData, Model
            ViewBag.clientes=clientes;
            ViewData["clientes"]=clientes;

            return View(clientes);
        }
    }
}

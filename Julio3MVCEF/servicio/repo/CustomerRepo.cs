using Julio3MVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore; // para usar Include
using System.Threading.Tasks;
using Julio3MVCEF.configuracion;

namespace Julio3MVCEF.servicio.repo
{
    public class CustomerRepo
    {
        // las constantes son valores que no se pueden cambiar.
        // usualmente las constantes se escriben en mayuscula
 

        public static List<Customer> ListarTodo()
        {
            var resultado=new List<Customer>();
            using(var contexto=new MilkCoContext())
            {
                resultado=contexto
                    .Customers
                    .Include( c => c.IdCityNavigation) // traigo los clientes con su ciudad
                    .OrderBy( c => c.FullName ) // c equivale a un cliente.
                    .ToList();

            } // se desconecta de la base de datos
         
            return resultado;
        }
        public static List<Customer> ListarPaginado(int inicial)
        {
            var resultado = new List<Customer>();
            using (var contexto = new MilkCoContext())
            {
                resultado = contexto
                    .Customers
                    .Include(c => c.IdCityNavigation) // traigo los clientes con su ciudad
                    .OrderBy(c => c.FullName) // c equivale a un cliente.
                    .Skip(inicial) //  salte ningun elemento
                    .Take(Configuracion.TAMPAGINA) // solo lea los siguientes 20 elementos.
                    .ToList();

            } // se desconecta de la base de datos

            return resultado;
        }
        public static void Insertar(Customer cus)
        {
            using(var contexto=new MilkCoContext())
            {
                contexto.Customers.Add(cus);
                contexto.SaveChanges();
            }
        }
        public static void Eliminar(int idCustomer)
        {
            using (var contexto = new MilkCoContext())
            {
                Customer cli=contexto.Customers.Find(idCustomer);
                contexto.Remove(cli);
                contexto.SaveChanges();
            }
        }
        public static void Eliminar(Customer cus)
        {
            using (var contexto = new MilkCoContext())
            {
                contexto.Customers.Remove(cus);
                contexto.SaveChanges();
            }
        }
        public static void Modificar(Customer clienteModificar)
        {
            using (var contexto = new MilkCoContext())
            {
                contexto.Customers.Update(clienteModificar);
                contexto.SaveChanges();
            }
        }
        public static Customer Obtener(int customerId)
        {
            var resultado=new Customer();
            using (var contexto = new MilkCoContext())
            {
                /*resultado=contexto
                    .Customers
                    .Find(customerId); find no se puede usar con include
                */
                resultado = contexto
                    .Customers
                    .Include(c => c.IdCityNavigation)
                    .Where(c => c.IdCustomer == customerId)
                    .FirstOrDefault(); // si no encuentra el valor, devuelve nulo
                    //.First(); // <-- si no encuentra el valor, se genera un error.                    
                /*resultado=contexto.Customers
                    .Where( c => c.IdCustomer==customerId )
                    .First();*/
            }
            return resultado;
        }
        public static int Contar()
        {
            int resultado=0;
            using (var contexto = new MilkCoContext())
            {
                resultado=contexto.Customers.Count();
            }
            return resultado;
        }

    }
}

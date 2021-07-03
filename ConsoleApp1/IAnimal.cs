using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // interface es una clase abstracta
    interface IAnimal
    {
        string Nombre { set; get; }
        string Peso { set; get; }
        string Raza { set; get; }
    }


    abstract class IAnimal2
    {
        string Nombre { set; get; }
        string Peso { set; get; }
        string Raza { set; get; }
    }
}

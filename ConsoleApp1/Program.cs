using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Perro snoopy=new Perro();
            Gato garfield=new Gato();

            IAnimal unAnimal=new Perro();
            unAnimal=new Gato();

        }
    }
}
